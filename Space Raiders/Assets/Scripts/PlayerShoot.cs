using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float fireDelay = 0.15f;
    float cooldownTimer = 0;

    private float shipHeight;
    private float shipWidth;

    public AudioSource clip;

    void Start(){
        shipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        
        if (Input.GetButton("Fire3") && cooldownTimer <= 0 ){
            //Disparo
            clip.Play();
            Debug.Log("Shoot!");
            cooldownTimer = fireDelay;

            Vector3 offset = new Vector3(0,shipHeight,0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
