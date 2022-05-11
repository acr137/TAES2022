using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //Cada nave tendra sus valores de velocidad
    public float baseSpeed = 6f;
    public float activeSpeed;
    public float dashSpeed;
    public float dashLength = 0.2f;
    public float dashCounter;
    public float dashCooldownCounter;
    public float dashCooldown = 1f;

    SpriteRenderer sprite;
    Color normalColor = new Color(1f,1f,1f,1f);
    Color dashingColor = new Color(1f,1f,1f,.5f);

    PolygonCollider2D hitbox;

    //Estos 2 valores dependen del sprite utilizado, se obtienen automaticamente
    private float shipHeight;
    private float shipWidth;

    private Vector2 screenBounds;

    // Animación de destrucción
    public GameObject explotion;

    private float oldSpeed;
    private float boostDuration;
    private bool boost;
    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = baseSpeed;
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
        dashSpeed = baseSpeed * 2.5f;
        //Obtencion de valores para el control de los bordes
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        shipWidth = transform.GetComponent<PolygonCollider2D>().bounds.size.x/2;
        shipHeight = transform.GetComponent<PolygonCollider2D>().bounds.size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 tempPos = transform.position;
        
        tempPos.y += Input.GetAxis("Vertical") * activeSpeed * Time.deltaTime;
        if ((tempPos.y + shipHeight < screenBounds.y) && (tempPos.y - shipHeight > (screenBounds.y * -1))){
            pos.y = tempPos.y;
        }

        tempPos.x += Input.GetAxis("Horizontal") * activeSpeed * Time.deltaTime;
        if ((tempPos.x + shipWidth < screenBounds.x) && (tempPos.x - shipWidth > (screenBounds.x * -1))){
            pos.x = tempPos.x;
        }

        transform.position = pos;

        if(Input.GetButtonDown("Jump")){
            if(dashCounter <=0 && dashCooldownCounter <= 0){
                activeSpeed = dashSpeed;
                dashCounter = dashLength;
                sprite.color = dashingColor;
                hitbox.enabled=false;
            }
        }

        if (dashCounter>0){
            dashCounter -= Time.deltaTime;

            if(dashCounter<=0){
                sprite.color = normalColor;
                hitbox.enabled=true;
                activeSpeed=baseSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }
        if(dashCooldownCounter>0){
            dashCooldownCounter -= Time.deltaTime;
        }

        //SpeedBoost powerup
        if(boostDuration > 0)
        {
            boostDuration -= Time.deltaTime;
        }
        else
        {
            if (boost)
            {
                baseSpeed = oldSpeed;
                activeSpeed = baseSpeed;
                boost = false;
            }
            
        }
    }

    public void speedBoost(float duration, float boostAmount)
    {
        oldSpeed = baseSpeed;
        baseSpeed += boostAmount;
        activeSpeed = baseSpeed;
        boostDuration = duration;
        boost = true;
    }
}
