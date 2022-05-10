using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : MonoBehaviour
{
    PlayerShoot pScript;
    public float duration = 7f;

    public GameObject shieldPrefab;
    GameObject controller;
    NotificationPowerup noti;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
        controller = GameObject.Find("Controller Powerups");
        noti = controller.GetComponent<NotificationPowerup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string desc = "Escudo (1 golpe)";
        noti.popup(desc);
        Vector3 offset1 = new Vector3(0, pScript.getShipHeight(), 0);
        GameObject shield = Instantiate(shieldPrefab,player.transform.position,player.transform.rotation);
        shield.transform.parent = player.transform;
        Destroy(gameObject);
    }
}
