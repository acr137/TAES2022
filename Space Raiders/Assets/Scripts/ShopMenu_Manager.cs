using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class ShopMenu_Manager : MonoBehaviour
{
    public AudioSource clip;

    /// <summary>
    /// Texto a proyectar
    /// </summary>
    public TextMeshProUGUI saldoText;
    private float saldo = 0;
    private string nombreSaldo = "saldo";
    private GameObject ButtonRef;

    private static int shopNum = 5;
    private bool[] itemsStatus = Enumerable.Repeat(true, shopNum).ToArray();

    public int[,] shopItems = new int[3, shopNum];

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("shopItemStatuse"))
        {
            itemsStatus = PlayerPrefsX.GetBoolArray("shopItemStatuse");
        }
        itemsStatus[0] = false;

        saldo = PlayerPrefs.GetFloat(nombreSaldo, 0);
        saldoText.text = "Saldo: " + saldo.ToString() + "€";

        //ID's
        shopItems[1, 1] = 1;

        //Price
        shopItems[2, 1] = 100;
    }

    public void selectShip()
    {
        ButtonRef = GameObject.FindGameObjectWithTag("ShopEvent").GetComponent<EventSystem>().currentSelectedGameObject;
    }

    public void Buy()
    {
        if(ButtonRef != null )
        {
            int ItemID = ButtonRef.GetComponent<ItemInfo>().ItemID;
            if (saldo >= shopItems[2, ItemID])
            {
                saldo -= shopItems[2, ItemID];
                saldoText.text = "Saldo: " + saldo.ToString() + "€";
                PlayerPrefs.SetFloat(nombreSaldo, saldo);
                // Block
                ButtonRef.GetComponent<Button>().interactable = false;
                itemsStatus[ItemID] = false;

                PlayerPrefsX.SetBoolArray("shopItemStatuse", itemsStatus);
                ButtonRef = null;
            }
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
