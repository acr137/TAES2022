using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageHandler : MonoBehaviour
{
    
    public int health = 1;

    public float invulnPeriod = 0;
    public float blinkPeriod = 0.5f;

    public GameObject explosion;
    
    float invulnTimer = 0;
    float blinkTimer = 0;
    SpriteRenderer sprite;
    Color normalColor = new Color(1f,1f,1f,1f);
    Color blinkColor = new Color(1f,1f,1f,.5f);
    PolygonCollider2D hitbox;

    public AudioSource clip1;
    public AudioSource clip2;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(){
        Debug.Log("Golpe");
        //clip1.Play();
        health--;
        if(health <= 0){
            //clip2.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        invulnTimer = invulnPeriod;
        blinkTimer = blinkPeriod;
}

    void Update()
    {
        if (invulnTimer>0){
            hitbox.enabled=false;
            invulnTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if(blinkTimer<=0){
                if(sprite.color == normalColor){
                    sprite.color = blinkColor;
                }else if (sprite.color == blinkColor){
                    sprite.color = normalColor;
                }
                blinkTimer = blinkPeriod;
            }
            if(invulnTimer <= 0){
                sprite.color = normalColor;
                hitbox.enabled=true;
            }
        }
    }
}
