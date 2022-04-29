using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds; //Nos da la mitad de los valores totales de la pantalla
    private float objectWith;
    private float objectHeight;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWith = transform.GetComponent<PolygonCollider2D>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<PolygonCollider2D>().bounds.size.y / 2;
        Debug.Log("SB.x: " + screenBounds.x);
        Debug.Log("SB.y: " + screenBounds.y );
        Debug.Log("Sprite.x: " + objectWith);
        Debug.Log("Sprite.y: " + objectHeight);
        //Debug.Log("Prueba Clamp: " + Mathf.Clamp(5, -6, 6));

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWith, screenBounds.x - objectWith); //Devuelve su posicion x dentro de los limites de la camara
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 -objectHeight, screenBounds.y + objectHeight);
        transform.position = viewPos;
    }
}
