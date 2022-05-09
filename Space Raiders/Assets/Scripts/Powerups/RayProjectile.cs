using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayProjectile : MonoBehaviour
{
    private float duration = 0f;
    // Update is called once per frame
    void Update()
    {
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        duration -= Time.deltaTime;
    }
}
