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

    public static int shopNum = 10;
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
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;

        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 400;
        shopItems[2, 5] = 500;
        shopItems[2, 6] = 600;
        shopItems[2, 7] = 700;
        shopItems[2, 8] = 800;
        shopItems[2, 9] = 900;
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
