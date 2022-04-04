using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ShopMenu_Manager : MonoBehaviour
{
    public AudioSource clip;

    public void goTo_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlaySoundButton(){
        clip.Play();
    }
}
