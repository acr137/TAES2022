using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BotonInfinito(){
        SceneManager.LoadScene("PlayerMovement");
    }

    public void BotonHistoria(){
        SceneManager.LoadScene("menu_niveles");
    }

    public void BotonTienda(){
        SceneManager.LoadScene("menu_tienda");
    }

    public void BotonSalir(){
        Application.Quit();
    }
}
