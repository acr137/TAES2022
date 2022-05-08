using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;
    public Text nombreNave;
    public AudioSource clip;

    private void Awake()
    {
        nombreNave.text = sr.sprite.name;    
    }

    public void NextOption()
    {
        clip.Play();
        selectedSkin = selectedSkin + 1;

        if (selectedSkin >= skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        nombreNave.text = sr.sprite.name;
    }

    public void BackOption()
    {
        clip.Play();
        selectedSkin = selectedSkin - 1;

        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
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
}
