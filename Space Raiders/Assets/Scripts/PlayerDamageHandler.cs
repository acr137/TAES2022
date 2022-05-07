using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    
    public int health = 1;
    public int maxHealth = 3;
    public float invulnPeriod = 1.2f;
    public float blinkPeriod = 0.2f;

    public GameObject explosion;
    public HealthBar healthBar;
    
    float invulnTimer = 0;
    float blinkTimer = 0;
    SpriteRenderer sprite;
    Color normalColor = new Color(1f,1f,1f,1f);
    Color blinkColor = new Color(1f,1f,1f,.5f);
    PolygonCollider2D hitbox;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
        healthBar.set(health,maxHealth);

        // Se inicializa la salud de forma global
        saveHealthGlobally(health);

        GameObject Salud = GameObject.Find("Salud");
        HealthBar SaludScript = Salud.GetComponent<HealthBar>();
        SaludScript.ChangeDmgHandler(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "powerup")
        {
            Debug.Log("Golpe");
            health--;
            healthBar.damage(1);
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);

                // Reproduce el sonido de Game Over
                GameObject goSound = GameObject.Find("GameOverAudio");
                if (goSound != null)
                {   // Evita que salte una excepción si el objeto del audio no existe en la escena
                    Instantiate(goSound, goSound.transform.position, goSound.transform.rotation);
                }

                Destroy(gameObject);
            }
            invulnTimer = invulnPeriod;
            blinkTimer = blinkPeriod;

            // Se actualiza la salud de forma global
            saveHealthGlobally(health);
        }
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

     public void repair(int hp){
        health+=hp;

        // Se actualiza la salud de forma global
        saveHealthGlobally(health);
    }

    public void add(int hp){
        maxHealth+=hp;
        health+=hp;

        // Se actualiza la salud de forma global
        saveHealthGlobally(health);
    }

    // Guarda la salud en una variable global
    private void saveHealthGlobally(int health)
    {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }
}
