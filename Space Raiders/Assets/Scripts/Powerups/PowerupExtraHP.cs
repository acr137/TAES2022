using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupExtraHP : MonoBehaviour
{
    public int healthAmount = 1;
    private HealthBar salud;

    private void Start()
    {
        GameObject barra = GameObject.Find("Salud");
        salud = barra.GetComponent<HealthBar>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        //GameObject player = collision.gameObject;
        //PlayerDamageHandler pScript = player.GetComponent<PlayerDamageHandler>();
        //pScript.repair(healAmount);
        salud.add(healthAmount);
        Destroy(gameObject);
    }
}