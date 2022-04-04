using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Seleccionar_nivel : MonoBehaviour
{
    public AudioSource clip;

    public void LoadNivel1() 
    {
        SceneManager.LoadScene("Nivel_1");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlaySoundButton(){
        clip.Play();
    }
}
