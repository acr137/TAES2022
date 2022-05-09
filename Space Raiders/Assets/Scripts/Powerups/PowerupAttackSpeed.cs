using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAttackSpeed : MonoBehaviour
{
    PlayerShoot pScript;
    public float boostAmount = 0.09f;
    public float duration = 7f;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        pScript.attackBoost(duration, boostAmount);

        Destroy(gameObject);
    }
}
