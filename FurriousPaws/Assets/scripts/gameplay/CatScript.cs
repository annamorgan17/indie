using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public float bottomYPos;
    public Gamemanager GM;
    void Update()
    {
        if (transform.position.y <= bottomYPos)
        {
            GM.GameOver();
        }
    }
}
