using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawn : MonoBehaviour //handles spawning the power ups 
{
    public GameObject powerUp;//object of the power up

    private float timeBtwSpawn; //time between each power up spawn

    public float startTimeBtwSpawn; //the starting time between spawns
    public float increaseTime; //the increase of said time
    public float maxTime = 40; //the max of said time
    void Update()
    {
        if (timeBtwSpawn <= 0) //if below or at 0, aka time to spawn 
        {
            Instantiate(powerUp, transform.position, Quaternion.identity); //create instance of power up
            timeBtwSpawn = startTimeBtwSpawn; //time between is set to start time
            if (startTimeBtwSpawn < maxTime) //if start time is lower than max time
            {
                startTimeBtwSpawn += increaseTime; //increase it by the increase
            }
        }
        else //if above
        {
            timeBtwSpawn -= Time.deltaTime; //start decreasing the time
        }
    }
}
