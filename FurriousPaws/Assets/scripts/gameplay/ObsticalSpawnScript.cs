using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawnScript : MonoBehaviour
{
    public GameObject obstical;
    void Start()
    {
        Instantiate(obstical, transform.position, Quaternion.identity);
    }
}
