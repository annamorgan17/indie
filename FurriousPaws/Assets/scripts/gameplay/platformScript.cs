using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour //deals with score and moving the platform
{
    public float speed; //speed it moves at
    public float increaseSpeed; //the amount the speed is increased
    void Update()
    {
        //moves the platforms x postion towards the left at the set speed
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other) //if the cat enters its trigger, increase the score and the speed
    {
        if(other.tag == "Cat")
        {
            SharedData.PlayerScore += 123;
             speed += increaseSpeed;
        }
        
    }
}
