using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSoundTrigger : MonoBehaviour
{
    // Audio de Game Over
    public AudioSource gameOverSound;

    // Controla que se haya usado el audio
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && !isAlive())
        {
            gameOverSound.Play();
            triggered = true;
        }
    }

    private bool isAlive()
    {
        return getHealth() > 0;
    }

    private int getHealth()
    {
        return PlayerPrefs.GetInt("health");
    }
}
