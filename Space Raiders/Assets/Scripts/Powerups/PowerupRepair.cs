using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRepair : MonoBehaviour
{
    public int healAmount = 1;
    private HealthBar salud;

    private void Start()
    {
        GameObject barra = GameObject.Find("Salud");
        salud = barra.GetComponent<HealthBar>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        salud.repair(healAmount);
        Destroy(gameObject);
    }
}
