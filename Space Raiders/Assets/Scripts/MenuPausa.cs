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

    public void PlaySoundButton(){
        clip.Play();
    }
}
