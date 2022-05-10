using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTripleShot : MonoBehaviour
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


        pScript.specialShot(1, 15f);


        Destroy(gameObject);
    }
}
