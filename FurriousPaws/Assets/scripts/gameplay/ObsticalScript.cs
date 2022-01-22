using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalScript : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cat")
        {
            SharedData.WasHit = true;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

}
