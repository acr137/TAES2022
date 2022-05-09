using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : MonoBehaviour
{
    PlayerShoot pScript;
    public float duration = 7f;

    public GameObject shieldPrefab;

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Powerup cogido");
        Vector3 offset1 = new Vector3(0, pScript.getShipHeight(), 0);
        GameObject shield = Instantiate(shieldPrefab,player.transform.position,player.transform.rotation);
        shield.transform.parent = player.transform;
        ////pScript.setShield(shield);
        //RelativeJoint2D joint = player.GetComponent<RelativeJoint2D>();
        //if (!joint)
        //{
        //    player.AddComponent<RelativeJoint2D>();
        //    joint = player.GetComponent<RelativeJoint2D>();
        //}
        //Rigidbody2D shieldbody = shield.GetComponent<Rigidbody2D>();
        //joint.connectedBody = shieldbody;
        //joint.enableCollision = false;
        Destroy(gameObject);
    }
}
