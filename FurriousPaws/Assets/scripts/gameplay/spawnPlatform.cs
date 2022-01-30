using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatform : MonoBehaviour//handles spawning the platforms 
{
    public GameObject[] platformPattern; //array of the different positions the platforms could spawn

    private float timeBtwSpawn;//time between each platform spawn

    public float startTimeBtwSpawn;//the starting time between spawns
    public float increaseTime;//the increase of said time
    public float maxTime = 2.65f;//the max of said time
    void Update()
    {
        if (timeBtwSpawn <= 0)//if below or at 0, aka time to spawn 
        {
            int randomPattern = Random.Range(0, platformPattern.Length); //pick a random number within length of array
            //using that number as the platform in array, spawn that pattern, this will then use the spawnPoint script to spawn a platform
            Instantiate(platformPattern[randomPattern], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;//time between is set to start time
            if (startTimeBtwSpawn < maxTime)//if start time is lower than max time
            {
                startTimeBtwSpawn += increaseTime;//increase it by the increase
            }
        }
        else//if above
        {
            timeBtwSpawn -= Time.deltaTime;//start decreasing the time
        }
    }
}
