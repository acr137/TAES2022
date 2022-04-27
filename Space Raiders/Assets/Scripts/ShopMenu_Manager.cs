using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class ShopMenu_Manager : MonoBehaviour
{
    public AudioSource clip;

    /// <summary>
    /// Texto a proyectar
    /// </summary>
    public TextMeshProUGUI saldoText;
    private int saldo = 0;
    private string nombreSaldo = "saldo";

    // Start is called before the first frame update
    void Start()
    {
        saldo = PlayerPrefs.GetInt(nombreSaldo, 0);

        saldoText.text = "Saldo: " + saldo.ToString();
    }

    public void substract(int coste)
    {
        int result = saldo - coste;
        if(result < 0)
        {

        }
        else
        {
            PlayerPrefs.SetInt(nombreSaldo, result);
        }
    }

    public void goTo_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySoundButton(){
        clip.Play();
    }
}
