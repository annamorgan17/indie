using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKGScript : MonoBehaviour //background script which moves and repeats the background image
{
    public float speed;//speed it moves

    public float endXPos; //off screen position for it to repeat from
    public float startXPos; //off screen position for it to repeat to

    void Update()
    {
        //move the x position by time and speed
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);

        if(transform.position.x <= endXPos) //if at the point where it should repeat
        {
            Vector3 pos = new Vector3(startXPos, transform.position.y, transform.position.z); //create a temporary vector which is where it will move to
            transform.position = pos; //move it to the start position
        }
    }
}
