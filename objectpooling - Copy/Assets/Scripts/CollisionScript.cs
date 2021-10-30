using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
{
    private int score = 0;
    private int health = 5;
   // public Text scoreText;
   // public Text healthText;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedPill"))
        {
            if (other.gameObject.transform.position.y < 5.0f)
                score++;
            else
                score--;
     //       scoreText.text = "Score :" + score;

            // GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("GreenPill"))
        {
            if (other.gameObject.transform.position.y < 5.0f)
                score--;
            else
                score++;
           // scoreText.text = "Score :" + score;
            // GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle")|| other.gameObject.CompareTag("Obstacle2")|| other.gameObject.CompareTag("Obstacle3"))
        {
            health--;
        //    healthText.text = "Health :"+health ;
            // GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }

    }
}
