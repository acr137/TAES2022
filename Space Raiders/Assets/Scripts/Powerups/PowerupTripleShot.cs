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

        if (pScript.shotType != 3)
        {
            pScript.shotType = 1;
        }
        else
        {
            pScript.oldShotType = 1;
        }

        Destroy(gameObject);
    }
}
