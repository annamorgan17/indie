using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalScript : MonoBehaviour //script that handles the obsticles in the scene
{
    public float speed;//speed it moves at
    public float increaseSpeed; //the increase the speed goes run by

    private bool hitTrigger = false; //if it can be hit by the player
    private SpriteRenderer obsticleRender; //the sprite renderer

    private void Start()
    {
        obsticleRender = GetComponent<SpriteRenderer>(); //connect renderer
    }
    private void OnTriggerEnter(Collider other) //when trigger is entered
    {
        if(other.tag == "Cat" && hitTrigger == false) //if its the cat and it can be hit
        {
            SharedData.WasHit = true; //set the was hit to true
        }
    }

    void Update()
    {
        //move the x pos by time and speed towards the left
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
        if(SharedData.PowerUp == true) //if power up is in effect
        {
            StartCoroutine(PowerUpEffectsOnObj()); //run the ienumerator for how power ups effect the obsticle
            speed = speed + increaseSpeed; //increase the speed
        }
    }

    private IEnumerator PowerUpEffectsOnObj() //sets it so it cannot be hit and is slighly see through then waits before resetting
    {
        hitTrigger = true;
        obsticleRender.color = new Vector4(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(6.5f);
        obsticleRender.color = new Vector4(1, 1, 1, 1);
        hitTrigger = false;
    }

}
