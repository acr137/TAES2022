using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    private bool active = true;
    public int ItemID;
    public TextMeshProUGUI PirceText;
    public TextMeshProUGUI NameText;
    public GameObject ShopManager;
    public Button thisItem;

    void Start()
    {
        if (PlayerPrefs.HasKey("shopItemStatuse"))
        {
            bool[] status = PlayerPrefsX.GetBoolArray("shopItemStatuse");
            active = status[ItemID];
            thisItem.interactable = active;
            PirceText.text = "sold";
        }
    }

    void Update()
    {
        if(active)
            PirceText.text = "" + ShopManager.GetComponent<ShopMenu_Manager>().shopItems[2, ItemID ].ToString() + "€";
        NameText.text = "nave-" + (ItemID + 1);
    }
}
