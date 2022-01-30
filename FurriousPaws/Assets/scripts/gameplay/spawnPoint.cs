using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour //simple script for spawning the platforms in this position
{
    public GameObject[] platforms;//array of platforms
    void Start()
    {
        int randomPlatform = Random.Range(0, platforms.Length); //pick a random number in array, aka a random platform
        Instantiate(platforms[randomPlatform], transform.position, Quaternion.identity); //spawn that random platform
    }

}
