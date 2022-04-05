using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float maxSpeed = 10f;

    void OnBecameInvisible() {
         Destroy(gameObject);
     }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime,0);
        pos += velocity;
        transform.position = pos;
    }
}
