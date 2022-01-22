using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public float bottomYPos;
    public Gamemanager GM;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y <= bottomYPos)
        {
            GM.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
   
   

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
