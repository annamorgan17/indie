using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour//deals with score and moving the power up
{
    public float speed;//speed it moves at
    public float increaseSpeed;//the amount the speed is increased
    void Update()
    {
        //moves the power ups x postion towards the left at the set speed
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)//if the cat enters its trigger, increase the score and the speed, then destory the object
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
