using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPowerup : MonoBehaviour
{
    private float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += velocity;
        transform.position = pos;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
