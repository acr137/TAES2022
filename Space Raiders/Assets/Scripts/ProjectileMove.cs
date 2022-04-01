using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float timeSelfDestruct = 5f;

    void Update()
    {
        timeSelfDestruct -= Time.deltaTime;

        if(timeSelfDestruct<= 0){
            Destroy(gameObject);
        }

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime,0);
        pos += velocity;
        transform.position = pos;
    }
}
