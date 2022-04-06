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
        if (gameControler.getSeconds() == 30f)
        {
            Debug.Log("Nivel completado");
            DialogueTrigger dialogoNarrador2 = narrador2.GetComponent<DialogueTrigger>();
            dialogoNarrador2.TriggerDialogue();
        }
        if (gameControler.getSeconds() == 31f)
        {
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
