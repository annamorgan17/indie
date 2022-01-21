using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour
{
    public GameObject[] platformPattern;

    private float timeBtwSpawn;

    public float startTimeBtwSpawn;
    public float increaseTime;
    public float maxTime = 2.65f;
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randomPattern = Random.Range(0, platformPattern.Length);
            Instantiate(platformPattern[randomPattern], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn < maxTime)
            {
                startTimeBtwSpawn += increaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
