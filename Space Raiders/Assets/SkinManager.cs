using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;
    public Text nombreNave;


    public void NextOption()
    {
        selectedSkin++;

        if (selectedSkin >= skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        nombreNave.text = sr.sprite.name;
    }

    public void BackOption()
    {
        selectedSkin--;

        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
        nombreNave.text = sr.sprite.name;
    }

    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Prefabs/Spaceship.prefab");

        switch (selectedSkin)
        {
            case 0:
                PlayerPrefs.SetString("ship", "Frigate1");
                break;
            case 1:
                PlayerPrefs.SetString("ship", "Spaceship");
                break;
        }
        SceneManager.LoadScene("nivel_infinito");
    }
}
