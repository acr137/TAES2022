using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDiagonal : MonoBehaviour
{
    PlayerShoot pScript;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        pScript.specialShot(2, 10f);

        Destroy(gameObject);
    }
}
