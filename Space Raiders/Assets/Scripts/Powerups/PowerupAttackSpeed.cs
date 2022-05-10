using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAttackSpeed : MonoBehaviour
{
    PlayerShoot pScript;
    public float boostAmount = 0.09f;
    public float duration = 7f;
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
        string desc = "Disparo rápido (7 seg)";
        noti.popup(desc);

        pScript.attackBoost(duration, boostAmount);

        Destroy(gameObject);
    }
}
