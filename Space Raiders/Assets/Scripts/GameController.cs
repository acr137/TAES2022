using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int Difficulty = 2;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        Debug.Log("Prefab Name: " + PlayerPrefs.GetString("ship"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(spawnValues.y, spawnValues.y + 5), spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
