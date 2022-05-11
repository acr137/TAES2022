using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;
    public Text nombreNave;
    public AudioSource clip;

    private bool[] itemsStatus = Enumerable.Repeat(true, ShopMenu_Manager.shopNum).ToArray();

    private void Awake()
    {
        nombreNave.text = sr.sprite.name;
        if (PlayerPrefs.HasKey("shopItemStatuse"))
        {
            itemsStatus = PlayerPrefsX.GetBoolArray("shopItemStatuse");
        }
        itemsStatus[0] = false;
    }

    private int searchNext()
    {
        int next = selectedSkin;

        for(int i = next; i < ShopMenu_Manager.shopNum && itemsStatus[i]; i++)
        {
            next = i;
        }

        return next;
    }

    public void NextOption()
    {
        clip.Play();
        do
        {
            selectedSkin = selectedSkin + 1;
            if (selectedSkin >= skins.Count)
            {
                selectedSkin = 0;
            }
        } while (itemsStatus[selectedSkin]);

        sr.sprite = skins[selectedSkin];
        nombreNave.text = sr.sprite.name;
    }

    public void BackOption()
    {
        clip.Play();
        do
        {
            selectedSkin = selectedSkin - 1;
            if (selectedSkin < 0)
            {
                selectedSkin = skins.Count - 1;
            }
        } while (itemsStatus[selectedSkin]);

        sr.sprite = skins[selectedSkin];
        nombreNave.text = sr.sprite.name;
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        clip.Play();

        PlayerPrefs.SetString("ship", skins[selectedSkin].name);
        PlayerPrefs.SetInt("posicion", selectedSkin);
        PlayerPrefs.Save();

        SceneManager.LoadScene("nivel_infinito");
    }

    // EASTER EGG
    public void PlayNanoGame()
    {
        clip.Play();

        PlayerPrefs.SetString("ship", "Nanonave");
        PlayerPrefs.SetInt("posicion", 10);
        PlayerPrefs.Save();

        SceneManager.LoadScene("nivel_infinito");
    }
}
