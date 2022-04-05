using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuPausa : MonoBehaviour
{
    public static bool estadoPausa = false;
    public GameObject menuPausaUI;
    public AudioSource clip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clip.Play();
            if (estadoPausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        clip.Play();
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        estadoPausa = false;
    }
    
    public void OptionsMenu()
    {
        clip.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void SalirJuego()
    {
        clip.Play();
        Debug.Log("Saliendo del juego...");
        SceneManager.LoadScene("MainMenu");
    }

    void Pause()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        estadoPausa = true;
    }
}
