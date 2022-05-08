using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI PirceTxt;
    public GameObject ShopManager;
    public Button thisItem;

    void Start()
    {
        if (PlayerPrefs.HasKey("shopItemStatuse"))
        {
            bool[] status = PlayerPrefsX.GetBoolArray("shopItemStatuse");
            thisItem.interactable = status[ItemID];
        }
    }

    void Update()
    {
        PirceTxt.text = "Price: " + ShopManager.GetComponent<ShopMenu_Manager>().shopItems[2, ItemID ].ToString() + "€";
    }
}
