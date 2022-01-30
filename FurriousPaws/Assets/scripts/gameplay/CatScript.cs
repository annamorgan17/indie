using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour //this is the script which handles anything to do with the player
{
    public float bottomYPos; //off screen position 
    public Gamemanager GM; //link to game manager script

    public Vector3 jump; //jump height
    public float jumpForce = 2.0f; //force/speed it'll jump

    public bool isGrounded; //whether it is on the ground
    Rigidbody rb; //the rigid body on the cat

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //connect to the rigidbody connected to this script's object
    }

    void Update()
    {
        if (transform.position.y <= bottomYPos) //if its fell off the screen
        {
            GM.GameOver(); //run the game over function
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //if space was pressed and on the ground
        {
            //add an impluse force to the rigidboyd to create a jump effect using the height and speed (jump * jumpForce)
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false; //chnage whether on ground
        }

        if(SharedData.PowerUp == true) //if there is a power in effect
        {
            StartCoroutine(PowerUpEffects()); //run the ienumerator for the power up effects
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true; //if steadily touching collider with another object then its on the ground
    }

    private IEnumerator PowerUpEffects() 
    {
        int count = transform.childCount; //temporary int for the amount of children attached to this
        for (int i = 0; i < count; i++) //loop through the children
        {
            Transform child = transform.GetChild(i); //temp transform to hold current child
            child.gameObject.SetActive(true); //set that child to active
        }

        yield return new WaitForSeconds(6.5f); //wait for 6.5f

        for (int i = 0; i < count; i++) //loop through children
        {
            Transform child = transform.GetChild(i); //temp transform to hold current child
            child.gameObject.SetActive(false);//set that child to inactive
        }

        SharedData.PowerUp = false; //change the power up to no longer in effect

    }
}
