using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    public float duration=7f;
    public float boostAmount=5f;
    PlayerMovement pScript;
    GameObject controller;
    NotificationPowerup noti;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerMovement>();
        controller = GameObject.Find("Controller Powerups");
        noti = controller.GetComponent<NotificationPowerup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string desc = "Te mueves más rápido (7 seg)";
        noti.popup(desc);

        pScript.speedBoost(duration, boostAmount);

        Destroy(gameObject);
    }
}
