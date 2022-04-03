using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //Cada nave tendra sus valores de velocidad
    public static float baseSpeed = 5f;
    public float activeSpeed = baseSpeed;
    public float dashSpeed = 10f;
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

    public static bool estadoPausa = false;
    public GameObject menuPausaUI;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();

        //Obtencion de valores para el control de los bordes
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        shipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estadoPausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        estadoPausa = false;
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        SceneManager.LoadScene("MainMenu");
    }

    void Pause()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        estadoPausa = true;
    }
}