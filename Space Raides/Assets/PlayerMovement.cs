using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Cada nave tendra sus valores de velocidad
    public float HorizontalSpeed = 7f;
    public float VerticalSpeed = 7f;

    //Estos 2 valores dependen del sprite utilizado, se obtienen automaticamente
    private float shipHeight;
    private float shipWidth;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
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
        
        tempPos.y += Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;
        if ((tempPos.y + shipHeight < screenBounds.y) && (tempPos.y - shipHeight > (screenBounds.y * -1))){
            pos.y = tempPos.y;
        }

        tempPos.x += Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
        if ((tempPos.x + shipWidth < screenBounds.x) && (tempPos.x - shipWidth > (screenBounds.x * -1))){
            pos.x = tempPos.x;
        }

        transform.position = pos;

    }

}
