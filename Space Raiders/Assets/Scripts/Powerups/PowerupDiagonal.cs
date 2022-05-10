using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDiagonal : MonoBehaviour
{
    PlayerShoot pScript;
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
        string desc = "Disparo diagonal (10 seg)";
        noti.popup(desc);

        pScript.specialShot(2, 10f);

        Destroy(gameObject);
    }
}
