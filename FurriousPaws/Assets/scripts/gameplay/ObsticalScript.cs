using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalScript : MonoBehaviour
{
    public float speed;
    public Gamemanager GM;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cat")
        {
            GM.GameOver();
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
    }

}
