using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalScript : MonoBehaviour
{
    public float speed;
    public float increaseSpeed;

    private bool hitTrigger = false;
    private SpriteRenderer obsticleRender;

    private void Start()
    {
        obsticleRender = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cat" && hitTrigger == false)
        {
            SharedData.WasHit = true;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
        if(SharedData.PowerUp == true)
        {
            StartCoroutine(PowerUpEffectsOnObj());
            speed += increaseSpeed;
        }
    }

    private IEnumerator PowerUpEffectsOnObj()
    {
        hitTrigger = true;
        obsticleRender.color = new Vector4(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(6.5f);
        obsticleRender.color = new Vector4(1, 1, 1, 1);
        hitTrigger = false;
    }

}
