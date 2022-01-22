using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    public float speed;
    public float increaseSpeed;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cat")
        {
            speed += increaseSpeed;
            SharedData.PowerUp = true;
            SharedData.PlayerScore += 173;
            Destroy(gameObject);
        }
    }

    
}
