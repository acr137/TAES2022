using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private float velocity;
    public GameObject explotion;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        velocity = Random.Range(((float)GameController.Difficulty), (float)GameController.Difficulty * 2.0f) * -1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = new Vector2(Random.Range(-0.5f, 0.5f), velocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explotion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
