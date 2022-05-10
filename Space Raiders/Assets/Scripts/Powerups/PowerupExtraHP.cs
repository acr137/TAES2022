using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupExtraHP : MonoBehaviour
{
    public int healthAmount = 1;
    private HealthBar salud;
    GameObject controller;
    NotificationPowerup noti;
    private void Start()
    {
        GameObject barra = GameObject.Find("Salud");
        salud = barra.GetComponent<HealthBar>();
        controller = GameObject.Find("Controller Powerups");
        noti = controller.GetComponent<NotificationPowerup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string desc = "Aumenta la salud máxima en 1";
        noti.popup(desc);

        salud.add(healthAmount);
        Destroy(gameObject);
    }
}