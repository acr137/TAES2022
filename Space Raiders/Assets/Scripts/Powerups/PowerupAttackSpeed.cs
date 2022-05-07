using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAttackSpeed : MonoBehaviour
{
    PlayerShoot pScript;
    public float boostAmount = 0.03f;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        pScript.fireDelay -= boostAmount;

        Destroy(gameObject);
    }
}
