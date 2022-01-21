using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cat")
        {
            //power effect
            SharedData.PlayerScore += 173;
            Destroy(gameObject);
        }
    }
}
