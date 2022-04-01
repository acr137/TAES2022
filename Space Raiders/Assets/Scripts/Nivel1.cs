using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel1 : MonoBehaviour
{
   
    public GameObject prefabEnemigo;
    public Vector3 spawnValues;
    public int numeroEnemigos;
    public int wave;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        spawnMeteor(); spawnMeteor();
        wave = 0;
        while (wave == 0) {
            if (numeroEnemigos == 3) wave =1;
            if (i == 0)
            {
                spawnMeteor();
                i++;
            }
            
        }
        spawnMeteor(); spawnMeteor(); spawnMeteor(); spawnMeteor(); spawnMeteor(); spawnMeteor();

    }

    // Update is called once per frame
    void Update()
    {
        numeroEnemigos = FindObjectsOfType<AsteroidMovement>().Length;
    }

    public void LoadMenu_niveles()
    {
        SceneManager.LoadScene("menu_niveles");
    }

    public void spawnMeteor() {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(spawnValues.y, spawnValues.y + 5), spawnValues.z);
        Instantiate(prefabEnemigo, spawnPosition, Quaternion.identity);
    }
}
