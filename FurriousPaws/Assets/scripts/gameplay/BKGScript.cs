using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKGScript : MonoBehaviour
{
    public float speed;

    public float endXPos;
    public float startXPos;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);

        if(transform.position.x <= endXPos)
        {
            Vector3 pos = new Vector3(startXPos, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
