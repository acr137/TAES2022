using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private float velocity;
    private int points = 10;
    private int difficulty;

    public GameObject explotion;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        difficulty = PlayerPrefs.GetInt("difficulty");
        velocity = Random.Range(difficulty, difficulty * 2.0f) * -1.0f;
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
            ScoreManager.instance.addPoints(points);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explotion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
