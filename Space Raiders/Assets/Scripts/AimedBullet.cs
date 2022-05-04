using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Hace que cuando se instancie un objeto, en nuestro caso será un proyectil, se dirija y rote hacia el jugador.
 Para que funcione el jugador debera llamarse Player y tendrá que tener PlayerMovement
 
 */
  
 
public class AimedBullet : MonoBehaviour
{
    public float moveSpeed = 7f;

    Rigidbody2D rb;

    PlayerMovement target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        try
        {
            target = GameObject.FindObjectOfType<PlayerMovement>();
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, 3f);
            Vector3 direccion = target.transform.position - transform.position;
            rb.rotation = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg * -1;
        }catch(NullReferenceException e) 
        {
            rb.velocity = new Vector2(0, -moveSpeed);
            rb.rotation = 180;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
