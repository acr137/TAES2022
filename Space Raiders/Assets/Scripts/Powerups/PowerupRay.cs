using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRay : MonoBehaviour
{
    PlayerShoot pScript;
    public float duration = 7f;

    public GameObject rayPrefab;
    GameObject controller;
    NotificationPowerup noti;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
        controller = GameObject.Find("Controller Powerups");
        noti = controller.GetComponent<NotificationPowerup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string desc = "Disparo laser (7 seg)";
        noti.popup(desc);

        pScript.shotType = 3;
        pScript.rayPowerUp(rayPrefab,duration);

        Destroy(gameObject);
    }
}
