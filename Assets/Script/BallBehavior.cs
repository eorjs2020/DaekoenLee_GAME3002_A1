using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            Score.scoreValue += 10;
            Destroy(collision.gameObject);
        }
         
        Destroy(gameObject);
    }
}
