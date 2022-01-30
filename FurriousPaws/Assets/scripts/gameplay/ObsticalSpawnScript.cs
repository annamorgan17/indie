using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawnScript : MonoBehaviour //simple script which creates an instance of a obsticle at this position
{
    public GameObject obstical;
    void Start()
    {
        Instantiate(obstical, transform.position, Quaternion.identity);
    }
}
