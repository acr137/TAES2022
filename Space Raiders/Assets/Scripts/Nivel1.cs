using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel1 : MonoBehaviour
{
    public GameObject prefabAsteroid;
    public GameObject narrador;
    // Start is called before the first frame update
    void Start()
    {
        DialogueTrigger dialogoNarrador = narrador.GetComponent<DialogueTrigger>();
        Debug.Log(dialogoNarrador);
        dialogoNarrador.TriggerDialogue();
        InstantiateAsteroid(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu_niveles()
    {
        SceneManager.LoadScene("menu_niveles");
    }

    public void InstantiateAsteroid(int x, int y) 
    {
        Instantiate(prefabAsteroid, new Vector2(x, y), prefabAsteroid.transform.rotation);
    }
}
