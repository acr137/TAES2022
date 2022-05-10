using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel3 : MonoBehaviour
{
    public GameObject prefabAsteroid;
    public GameObject narrador;
    public GameObject narrador2;
    public GameObject narrador3;
    public GameController gameControler;
    public GameObject powerUp;
    public GameObject powerUp2;
    public GameObject powerUp3;
    private GameObject player;
    private bool end = false;
    private bool fase2 = false;
    private bool fase3 = false;
    private bool death = false;
    private bool succes = false;
    private float timeDeath = 0;
    private float timeSucces;
    // Start is called before the first frame update
    void Start()
    {
        powerUp.GetComponent<FloatPowerup>().enabled = false;
        powerUp2.GetComponent<FloatPowerup>().enabled = false;
        powerUp3.GetComponent<FloatPowerup>().enabled = false;
        player = GameObject.Find("Frigate1");
        player.GetComponent<PlayerShoot>().enabled = false;
        gameControler = FindObjectOfType<GameController>();
        DialogueTrigger dialogoNarrador = narrador.GetComponent<DialogueTrigger>();
        Debug.Log("Empieza nivel 2");
        dialogoNarrador.TriggerDialogue();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Frigate1")) //SOLO SE PUEDE JUGAR CON Frigate1 A NO SER QUE SE CAMBIE ESTA LINEA
        {
            death = true;

        };
        if (death == true)
        {

            Debug.Log("TD: " + timeDeath);

            timeDeath += Time.deltaTime;
            if (timeDeath > 1) SceneManager.LoadScene("MainMenu");
            return;
        }
        if (gameControler.getSeconds() == 15f && fase2 == false)
        {

            fase2 = true;
            Debug.Log("Fase 2");
            DialogueTrigger dialogoNarrador2 = narrador2.GetComponent<DialogueTrigger>();
            dialogoNarrador2.TriggerDialogue();
            Instantiate(powerUp,  new Vector3(0, -2, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            Instantiate(powerUp2, new Vector3(3, -4, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            Instantiate(powerUp3, new Vector3(-3, -4, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            player.GetComponent<PlayerShoot>().enabled = true;
        }
        if (fase2 == true && end == false && !GameObject.Find("Enemy UFO 2(Clone)"))
        {

            end = true;
            Debug.Log(fase2);
            Debug.Log("Nivel completado");
            DialogueTrigger dialogoNarrador3 = narrador3.GetComponent<DialogueTrigger>();
            dialogoNarrador3.TriggerDialogue();
            succes = true;
        }
        if (gameControler.getSeconds() == 30f && fase3==false)
        {
            fase3 = true;
            DialogueTrigger dialogoNarrador3 = narrador3.GetComponent<DialogueTrigger>();
            dialogoNarrador3.TriggerDialogue();
            succes = true;
        }


        if (succes == true)
        {

            Debug.Log("TD: " + timeDeath);

            timeSucces += Time.deltaTime;
            if (timeSucces > 1) SceneManager.LoadScene("menu_niveles");
            return;
        }

    }

    public void LoadMenu_niveles()
    {
        SceneManager.LoadScene("menu_niveles");
    }

    public void InstantiateAsteroid(int x, int y)
    {
        Instantiate(prefabAsteroid, new Vector2(x, y), prefabAsteroid.transform.rotation);
    }

    public void End()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
