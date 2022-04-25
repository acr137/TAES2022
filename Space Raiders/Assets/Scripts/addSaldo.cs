using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class addSaldo : MonoBehaviour
{
    public AudioSource clip;
    private string saldo;
    private int saldoInt;
    private string nombreSaldo = "saldo";

    
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
            //MOSTRAR UN MENSAJE DE ERROR SI NO SE INTRODUCE
            // UN ENTERO O NO SE INTRODUCE NADA
            saldoInt += Int32.Parse(saldo);
            Debug.Log(saldoInt);
        } catch(FormatException e){
            Debug.Log(e.Message);
        } catch(ArgumentNullException e){
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
        PlayerPrefs.SetInt(nombreSaldo, saldoInt);
    }

    public void LoadData()
    {
        saldoInt = PlayerPrefs.GetInt(nombreSaldo, 0);
    }
}
