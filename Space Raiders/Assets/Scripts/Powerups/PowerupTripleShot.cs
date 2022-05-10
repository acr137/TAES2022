using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTripleShot : MonoBehaviour
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
        string desc = "Disparo triple (15 seg)";
        noti.popup(desc);

        pScript.specialShot(1, 15f);


        Destroy(gameObject);
    }
}
