using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float spawnTime = 2f;
    private float timeNow = 0f;

    public GameObject platform1;
    public GameObject platform;

    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        if (timeNow >= spawnTime) {
            timeNow = 0f;
            spawn();
        }
    }

    private void spawn() {
        int rd = Random.Range(0, 2);
        switch (rd) {
            case 0:
                Instantiate(platform1, new Vector3(15, Random.Range(-3, 1.2f), 0), transform.rotation);
            break;
            case 1:
                Instantiate(platform1, new Vector3(15, Random.Range(-3, 1.2f), 0), transform.rotation);
            break;
        }
    }
}
