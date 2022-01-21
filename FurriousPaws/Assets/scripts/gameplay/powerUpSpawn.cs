using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawn : MonoBehaviour
{
    public GameObject powerUp;

    private float timeBtwSpawn;

    public float startTimeBtwSpawn;
    public float increaseTime;
    public float maxTime = 40;
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn < maxTime)
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
