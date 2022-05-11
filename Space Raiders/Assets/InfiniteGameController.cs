using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteGameController : MonoBehaviour
{
    // Constantes globales
    private readonly int DIFFICULTY_INCREASE_PERIOD = 30/*segundos*/;
    private readonly int GENERATION_TIME = 5/*segundos*/;

    // Propiedades privadas
    private int difficulty;
    private float elapsedTime;
    private float minutes, seconds;
    private bool changingDifficulty = false;
    private bool enemyGenerated = false;

    // Propiedades p�blicas
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;
    public GameObject[] naves;

    public static bool estadoPausa = false;
    public GameObject menuPausaUI;
    // GameObject de la pantalla de Game Over
    public GameObject gameOverPanel;

    public TextMeshProUGUI textMinutes, textSeconds;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerPrefs.SetInt("difficulty", 1);
        PlayerPrefs.Save();

        // Hace que el tiempo pase de forma normal
        Time.timeScale = 1f;

        elapsedTime = 0;

        estadoPausa = false;
    }

    private void Awake()
    {
        // Inicializa la difficultad
        PlayerPrefs.SetInt("difficulty", 1);
        PlayerPrefs.Save();
        difficulty = PlayerPrefs.GetInt("difficulty");
        Debug.Log("Nivel de dificultad: " + difficulty);

        // Inicia la generaci�n de enemigos
        StartCoroutine(SpawnWaves());

        //GameObject prefabPlayer= Resources.Load("Prefabs/" + PlayerPrefs.GetString("ship")) as GameObject;
        //GameObject.Instantiate(prefabPlayer);
        naves[PlayerPrefs.GetInt("posicion")].SetActive(true);

        // Reinicia la variable
        PlayerPrefs.SetInt("posicion", 0);
        PlayerPrefs.Save();

        Debug.Log("Prefab Name: " + PlayerPrefs.GetString("ship"));
        Debug.Log("Prefab Posicion: " + PlayerPrefs.GetInt("posicion"));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estadoPausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        timerUpdate();

        if (!changingDifficulty && isTimeToIncreaseDifficulty())
        {
            changingDifficulty = true;
            incrementDifficulty();
            Debug.Log(difficulty);
        }

        if (changingDifficulty && !isTimeToIncreaseDifficulty())
        {
            changingDifficulty = false;
        }

        // Muestra un enemigo cada 10 segundos
        if (!enemyGenerated && isTimeToGenerateEnemy())
        {
            enemyGenerated = true;
            generateEnemy();
        }

        if (enemyGenerated && !isTimeToGenerateEnemy())
        {
            enemyGenerated = false;
        }

        //Debug.Log("Salud : " + PlayerPrefs.GetInt("health"));
        if (getHealth() < 1)
        {
            GameOver();
        }
    }

    public void Resume()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        estadoPausa = false;

        // Deja de mostrar el mensaje de Game Over si est� activo
        gameOverPanel.SetActive(false);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    private void Pause()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        estadoPausa = true;
    }

    // Activa la pantalla de Game Over
    private void GameOver()
    {
        gameOverPanel?.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount + difficulty; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(spawnValues.y, spawnValues.y + 5), spawnValues.z);
                Instantiate(hazards[0], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(Mathf.Max((waveWait / 1f + 0.1f * (float)difficulty), 0.5f));
        }
    }

    private void incrementDifficulty()
    {
        saveDifficulty(difficulty++);

        // Al cambiar de dificultad, se suman 100 puntos
        ScoreManager.instance.addPoints(100);

        generateEnemy();
    }

    // Genera un enemigo aleatoriamente
    private void generateEnemy()
    {
        // Genera enemigo especial
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(spawnValues.y, spawnValues.y + 5), spawnValues.z);
        // Elige aleatoriamente el enemigo que va a generar
        int random = Random.Range(0, 99);
        int enemy = 0;

        if (random < 30)
        {
            enemy = 1;
        }
        else if (random < 80)
        {
            enemy = 2;
        }
        else
        {
            enemy = 3;
        }

        Debug.Log("Ha salido el n�mero " + random + ". As� que se ha generado el enemigo " + enemy);

        Instantiate(hazards[enemy], spawnPosition, Quaternion.identity);
    }

    // Guarda el valor de la dificultad en la variable global asignada
    private void saveDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.Save();
    }

    private void timerUpdate()
    {
        elapsedTime += Time.deltaTime;

        minutes = Mathf.FloorToInt(elapsedTime / 60);
        textMinutes.text = timeToString(minutes);

        seconds = Mathf.FloorToInt(elapsedTime % 60);
        textSeconds.text = timeToString(seconds);
    }

    private string timeToString(float time)
    {
        string timeStr = "";

        if (time < 10)
        {
            timeStr += "0";
        }

        timeStr += time.ToString();

        return timeStr;
    }

    private bool isTimeToIncreaseDifficulty()
    {
        if (!isGameStart() &&
            timeToSeconds() % DIFFICULTY_INCREASE_PERIOD == 0)
        {
            return true;
        }

        return false;
    }

    private bool isTimeToGenerateEnemy()
    {
        if (timeToSeconds() % GENERATION_TIME == 0)
        {
            return true;
        }

        return false;
    }

    private float timeToSeconds()
    {
        return minutes * 60 + seconds;
    }

    bool isGameStart()
    {
        return (seconds == 0 && minutes == 0);
    }

    public float getSeconds()
    {
        return seconds;
    }

    private int getHealth()
    {
        return PlayerPrefs.GetInt("health");
    }
}