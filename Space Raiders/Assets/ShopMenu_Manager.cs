using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopMenu_Manager : MonoBehaviour
{
    public void goTo_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
