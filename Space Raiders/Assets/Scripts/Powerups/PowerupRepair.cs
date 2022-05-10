using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRepair : MonoBehaviour
{
    public int healAmount = 1;
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
        string desc = "Repara la nave (1 salud)";
        noti.popup(desc);

        salud.repair(healAmount);
        Destroy(gameObject);
    }
}
