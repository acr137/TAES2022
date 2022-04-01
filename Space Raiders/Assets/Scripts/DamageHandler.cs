using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    
    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(){
        Debug.Log("Golpe");
        health--;
        if(health <= 0){
            Destroy(gameObject);
        }
        invulnTimer = invulnPeriod;
        gameObject.layer=10;
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if(invulnTimer <= 0){
            gameObject.layer=correctLayer;
        }
    }
}
