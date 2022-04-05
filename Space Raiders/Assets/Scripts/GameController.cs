using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Propiedades privadas
    private int difficulty;
    private float timer;

    // Propiedades p�blicas
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;
    public GameObject[] naves;

    public static bool estadoPausa = false;
    public GameObject menuPausaUI;

    public TextMeshProUGUI textTimer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("difficulty", 1);
        PlayerPrefs.Save();

        timer = 0;
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
    }

    void timerUpdate()
    {
        timer += Time.deltaTime;
        textTimer.text = "" + timer.ToString("f1");
    }
}