using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRay : MonoBehaviour
{
    PlayerShoot pScript;
    public float duration = 7f;

    public GameObject rayPrefab;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        pScript.shotType = 3;
        pScript.rayPowerUp(rayPrefab,duration);

        Destroy(gameObject);
    }
}
