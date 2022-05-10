using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    AsyncOperation loadOperation;

    void Start()
    {
        loadOperation = SceneManager.LoadSceneAsync("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
