using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPowerups : MonoBehaviour
{
    public float interval = 15f;
    private float timer = 0f;
    public GameObject[] powerups;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;

            System.Random rnd = new System.Random();
            int p = rnd.Next(0, powerups.Length);

            float spawnY = Random.Range
                   (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
            
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            Instantiate(powerups[p],spawnPosition,Quaternion.identity);
        }
    }
}
