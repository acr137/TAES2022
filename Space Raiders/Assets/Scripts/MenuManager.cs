using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public AudioSource clip;
    
    public void BotonInfinito(){
        SceneManager.LoadScene("menu_selectNave");
    }

    public void BotonHistoria(){
        SceneManager.LoadScene("menu_niveles");
    }

    public void BotonTienda(){
        SceneManager.LoadScene("menu_tienda");
    }

    public void BotonSaldo(){
        SceneManager.LoadScene("saldo");
    }

    public void BotonSalir(){
        PlayerPrefs.SetInt("saldo", 0);
        Application.Quit();
    }

    public void PlaySoundButton(){
        clip.Play();
    }
}
