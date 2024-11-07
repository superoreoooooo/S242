using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnTimer = 1;
    public GameObject prefabToSpawn;
    private float timer = 0;
    public int maxNumGhost = 20;
    public int numGhost = 0;

    void Start() { }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTimer && numGhost < maxNumGhost)
        {
            SpawnGhost();
            timer -= spawnTimer;
            numGhost++;
        }
    }
    public void SpawnGhost()
    {
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran * Mathf.Deg2Rad) * 3f;
        float z = Mathf.Sin(ran * Mathf.Deg2Rad) * 3f;
        Vector3 randomPosition = transform.position + new Vector3(x, 0, z);
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }
}