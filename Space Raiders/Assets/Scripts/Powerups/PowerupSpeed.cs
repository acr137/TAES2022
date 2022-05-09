using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    public float duration=7f;
    public float boostAmount=5f;
    PlayerMovement pScript;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");

        //float oldSpeed = pScript.baseSpeed;
        //pScript.baseSpeed += 1.5f;
        //pScript.activeSpeed = pScript.baseSpeed;
        pScript.speedBoost(duration, boostAmount);

        Destroy(gameObject);
    }
}
