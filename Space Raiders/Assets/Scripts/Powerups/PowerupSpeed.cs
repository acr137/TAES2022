using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    PlayerMovement pScript;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        
        pScript.baseSpeed += 1.5f;
        pScript.activeSpeed = pScript.baseSpeed;

        Destroy(gameObject);
    }
}
