using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PENSADO PARA ENEMIGOS INTELIGENTES. CUANDO EL ENEMIGO APARECE SE COLOCA A UNA ALTURA Y EMPIEZA A MOVERSE DE IZQUIERDA A DERECHA
 * TIENE TRES FASES, COLOCACIÓN, MOVIMIENTO IZQUIERDA DERECHA Y HUIDA
 * LA ALTURA SE PUEDE CAMBIAR CON modifyStopPosition
 * SE PUEDE AJUSTAR LA VELOCIDAD DE CAIDA MIENTRAS SE MUEVE DE IZQUIERDA A DERECHA CON fallSpeed
 * PUEDE ELEGIR SI HUYE Y EN QUE DIRECCIÓN
 * */
public class HorizontalEnemyMovement : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;
    public bool runsAway = true;
    public char runAwayDirecction = 'd'; //u,d,l,r = up,down,left,right
    public int timeBeforeRunsAway = 1000;
    public int modifyStopPosition = 0;
    public int fallSpeed = 0;
    private int phase = 0;
    [HideInInspector]
    int runAwayCounter = 0;
    private Vector2 screenBounds; //Nos da la mitad de los valores totales de la pantalla
    private float objectWith;
    private float objectHeight;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWith = transform.GetComponent<PolygonCollider2D>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<PolygonCollider2D>().bounds.size.y / 2;

    }

    
    void Update()
    {
        switch (phase)
        {
            case 0:
                setUpPosition(); //Colocacion
                break;
            case 1:
                moveLeftRight();//Movimiento
                break;
            case 2:
                runAway(); //Huida
                break;
            default:
                Debug.Log("Error en fase de comportamiento");
                break;

        }
    }
    //Se coloca en posición antes de moverse de izquierda a derecha
    void setUpPosition()
    {
        int direccion; //Se calcula si se esta encima o debajo de la posiciona colocarse para saber la direccion que tomar
        if (transform.position.y < (screenBounds.y - (screenBounds.y / 4) + modifyStopPosition)) direccion = 1;
        else direccion = -1;
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(speed * Time.fixedDeltaTime) * direccion);
        if( Mathf.Abs(transform.position.y - (screenBounds.y - (screenBounds.y / 4) + modifyStopPosition)) <= 0.1f )
        {
            /*
            Debug.Log("Stop pos: " + (screenBounds.y - (screenBounds.y / 4)));
            Debug.Log("Pos: " + transform.position.y);
            Debug.Log("Comp: " + (1f * 1f));
            Debug.Log("Cambio a fase 1");
            */
            phase = 1;
        }
        

        
    }
    //Se mueve de izquierda a derecha
    void moveLeftRight() 
    {
       /*
       Debug.Log("CLI: " + screenBounds.x * -1);
       Debug.Log("Pos: " + transform.position.x);
       Debug.Log("CLD: " + screenBounds.x);
       */
        
        if (transform.position.x < screenBounds.x * -1 + objectWith)
        {
            speed = Mathf.Abs(speed);
        }
        else if (transform.position.x > screenBounds.x - objectWith)
        {
            speed = Mathf.Abs(speed) * -1;
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, fallSpeed * -1 * Time.fixedDeltaTime);
        Debug.Log(runAwayCounter);
        Debug.Log(timeBeforeRunsAway);
        if (runAwayCounter >= timeBeforeRunsAway && runsAway == true)
        {
            phase = 2;
            Debug.Log("Cambio a fase 2");
        }
        runAwayCounter++;
    }
    //huye hacia alante
    void runAway()
    {
        switch (runAwayDirecction)
        {
            case 'u':
                rb.velocity = new Vector2(0, Mathf.Abs(speed * Time.fixedDeltaTime));
                break;
            case 'd':
                rb.velocity = new Vector2(0, Mathf.Abs(speed * Time.fixedDeltaTime) * -1);
                break;
            case 'l':
                rb.velocity = new Vector2(Mathf.Abs(speed * Time.fixedDeltaTime) * -1, 0);
                break;
            case 'r':
                rb.velocity = new Vector2(Mathf.Abs(speed * Time.fixedDeltaTime), 0);
                break;
            default:
                rb.velocity = new Vector2(0, Mathf.Abs(speed * Time.fixedDeltaTime) * -1); // Hacia abajo por defecto
                break;
        }
    }
}
