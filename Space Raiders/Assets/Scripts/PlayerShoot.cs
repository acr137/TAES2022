using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject rayPrefab;

    public float fireDelay = 0.15f;
    private float cooldownTimer = 0;
    public int shotType = 0;

    private float shipHeight;
    private float shipWidth;

    private float boostDuration;
    private bool boost;
    private float oldFireDelay;

    private float rayDuration;
    public int oldShotType;
    public AudioSource clip;

    void Start(){
        shipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (shotType == 3)
        {
            if (Input.GetButton("Fire3"))
            {
                rayShot();
            }

            rayDuration -= Time.deltaTime;

            if(rayDuration <= 0)
            {
                shotType = oldShotType;
            }
        }
        else
        {
            //disparo normal, triple, o diagonal
            if (Input.GetButton("Fire3") && cooldownTimer <= 0)
            {
                //Disparo
                clip.Play();
                //Debug.Log("Shoot!");
                cooldownTimer = fireDelay;

                if (shotType == 0)
                {
                    normalShot();
                }
                else if (shotType == 1)
                {
                    tripleShot();
                }
                else if (shotType == 2)
                {
                    diagonalShot();
                }
            }
        }

        if (boostDuration > 0)
        {
            boostDuration -= Time.deltaTime;
        }
        else
        {
            if (boost)
            {
                fireDelay = oldFireDelay;
                boost = false;
            }

        }

    }
    void rayShot()
    {
        Vector3 offset = new Vector3(0, shipHeight+4f, 0);
        Instantiate(rayPrefab, transform.position + offset, transform.rotation);
    }

    void diagonalShot()
    {
        Vector3 offset1 = new Vector3(0, shipHeight, 0);
        Vector3 offset2 = new Vector3(0.2f, shipHeight, 0);
        Vector3 offset3 = new Vector3(-0.2f, shipHeight, 0);

        Instantiate(bulletPrefab, transform.position + offset1, transform.rotation);
        Instantiate(bulletPrefab, transform.position + offset2, transform.rotation * Quaternion.Euler(0f, 0f, -45f));
        Instantiate(bulletPrefab, transform.position + offset3, transform.rotation * Quaternion.Euler(0f, 0f, 45f));
    }
    void normalShot()
    {
        Vector3 offset = new Vector3(0, shipHeight, 0);
        Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
    }
    void tripleShot()
    {
        Vector3 offset1 = new Vector3(0, shipHeight, 0);
        Vector3 offset2 = new Vector3(0.2f, shipHeight, 0);
        Vector3 offset3 = new Vector3(-0.2f, shipHeight, 0);

        Instantiate(bulletPrefab, transform.position + offset1, transform.rotation);
        Instantiate(bulletPrefab, transform.position + offset2, transform.rotation);
        Instantiate(bulletPrefab, transform.position + offset3, transform.rotation);
    }

    public void attackBoost(float duration, float boostAmount)
    {
        oldFireDelay = fireDelay;
        fireDelay -= boostAmount;
        boostDuration = duration;
        boost = true;
    }
    public void rayPowerUp(GameObject ray, float duration)
    {
        rayDuration = duration;
        rayPrefab = ray;
    }

    public float getShipHeight()
    {
        return shipHeight;
    }
}
