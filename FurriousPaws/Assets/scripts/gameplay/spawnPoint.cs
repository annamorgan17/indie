using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public GameObject[] platforms;
    void Start()
    {
        int randomPlatform = Random.Range(0, platforms.Length); 
        Instantiate(platforms[randomPlatform], transform.position, Quaternion.identity);
    }

}
