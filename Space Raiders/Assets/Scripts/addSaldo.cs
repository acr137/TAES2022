using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class addSaldo : MonoBehaviour
{
    public AudioSource clip;
    private string saldo;
    private float saldoFloat;
    private string nombreSaldo = "saldo";
    public TextMeshProUGUI error;

    
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readSaldo(string saldo)
    {
        this.saldo = saldo;
    }

    public void sendSaldo()
    {
        try{
            saldo = saldo.Replace(".", ",");
            saldoFloat += float.Parse(saldo);
            Debug.Log(saldoFloat);
        } catch(FormatException e){
            error.text = "*Debes introducir un numero*";
            Debug.Log(e.Message);
        } catch(ArgumentNullException e){
            error.text = "*Debes introducir un numero*";
            Debug.Log(e.Message);
        }
    }

    public void back()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }

    private void OnDestroy()
    {
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat(nombreSaldo, saldoFloat);
    }

    public void LoadData()
    {
        saldoFloat = PlayerPrefs.GetFloat(nombreSaldo, 0);
    }
}
