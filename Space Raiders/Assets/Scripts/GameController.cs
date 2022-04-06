using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Constantes globales
    private readonly int DIFFICULTY_INCREASE_PERIOD = 30;

    // Propiedades privadas
    private int difficulty;
    private float elapsedTime;
    private float minutes, seconds;
    private bool changingDifficulty = false;

    // Propiedades públicas
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;
    public GameObject[] naves;

    public static bool estadoPausa = false;
    public GameObject menuPausaUI;

    public TextMeshProUGUI textMinutes, textSeconds;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("difficulty", 1);
        PlayerPrefs.Save();

        elapsedTime = 0;
    }

    private void Awake()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        Debug.Log("Nivel de dificultad: " + difficulty);

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
    void Update()
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
    }

    public void Resume()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        estadoPausa = false;
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        SceneManager.LoadScene("MainMenu");
    }

    void Pause()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        estadoPausa = true;
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(spawnValues.y, spawnValues.y + 5), spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void incrementDifficulty()
    {
        difficulty++;
        PlayerPrefs.SetInt("difficulty", difficulty);
        // Al cambiar de dificultad, se suman 100 puntos
        ScoreManager.instance.addPoints(100);
    }

    void timerUpdate()
    {
        elapsedTime += Time.deltaTime;

        minutes = Mathf.FloorToInt(elapsedTime / 60);
        textMinutes.text = timeToString(minutes);

        seconds = Mathf.FloorToInt(elapsedTime % 60);
        textSeconds.text = timeToString(seconds);
    }

    string timeToString(float time)
    {
        string timeStr = "";

        if (time < 10)
        {
            timeStr += "0";
        }

        timeStr += time.ToString();

        return timeStr;
    }

    bool isTimeToIncreaseDifficulty()
    {
        if (!isGameStart() && seconds % DIFFICULTY_INCREASE_PERIOD == 0)
        {
            return true;
        }

        return false;
    }

    bool isGameStart()
    {
        return (seconds == 0 && minutes == 0);
    }

    public float getSeconds() { return seconds;}
}