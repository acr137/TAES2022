using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel1 : MonoBehaviour
{
    public GameObject prefabAsteroid;
    public GameObject narrador;
    public GameObject narrador2;
    public GameController gameControler;
    private bool end = false;
    private bool end2 = false;
    private bool death = false;
    private float timeOfDeath;
    private float timeDeath = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = FindObjectOfType<GameController>();
        DialogueTrigger dialogoNarrador = narrador.GetComponent<DialogueTrigger>();
        Debug.Log("Empieza nivel 1");
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
            if(timeDeath > 1) SceneManager.LoadScene("menu_niveles");
            return;
        }
        if (gameControler.getSeconds() == 30f && end == false)
        {
            end = true;
            Debug.Log("Nivel completado");
            DialogueTrigger dialogoNarrador2 = narrador2.GetComponent<DialogueTrigger>();
            dialogoNarrador2.TriggerDialogue();
        }
        if (gameControler.getSeconds() == 31f && end2 == false)
        {
            Debug.Log("end2 = true");
            end2 = true;
            Time.timeScale = 1f;
            End();
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
        SceneManager.LoadScene("menu_niveles");

    }
}
