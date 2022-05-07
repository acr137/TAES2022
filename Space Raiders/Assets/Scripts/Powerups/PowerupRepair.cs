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

        //GameObject player = collision.gameObject;
        //PlayerDamageHandler pScript = player.GetComponent<PlayerDamageHandler>();
        //pScript.repair(healAmount);
        salud.repair(healAmount);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
