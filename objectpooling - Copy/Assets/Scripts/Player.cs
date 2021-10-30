using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public System.Random ran = new System.Random();

    public GameObject goodHit;
    public GameObject badHit;
    public GameObject obstacleHit;
    public GameObject switchLevelMusic;

    private int score = 0;
    private int health = 3;
    public Text scoreText;
    public Text healthText;
    public Material green;
    public Material red;
    public Material blue;
    // Update is called once per frame
    float timer = 0.0f;
    int switchTime = 15;
    float translateSpeed = 8.0f;
    private int colorNumber = 1;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = green;
        colorNumber = 1;
        resetPosition();

    }
    void Update()
    {
        timer =timer+ Time.deltaTime;
        // UnityEngine.Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.E))
        {
            health=health+1;
            healthText.text = "Health :" + health;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            score=score+10;
            scoreText.text = "Score :" + score;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (gameObject.GetComponent<Renderer>().sharedMaterial == green)
            {
                gameObject.GetComponent<Renderer>().material = red;
                colorNumber = 2;
            }
            else if (gameObject.GetComponent<Renderer>().sharedMaterial == red)
            {
                gameObject.GetComponent<Renderer>().material = blue;
                colorNumber = 3;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = green;
                colorNumber = 1;
            }
            timer = 0;
        }
        if ((int)timer == switchTime)

        {
           int generatedNumber= GenerateRandomNumber();
            if (generatedNumber == 1)
            {
                gameObject.GetComponent<Renderer>().material = green;
                colorNumber = 1;

            }
            else if (generatedNumber == 2)
            {
                gameObject.GetComponent<Renderer>().material = red;
                colorNumber = 2;
            }
            else if (generatedNumber == 3)
            {
                gameObject.GetComponent<Renderer>().material = blue;
                colorNumber = 3;

            }
            timer = 0;
        }
        float playerPositionX = transform.position.x;

        float playerPositionY = transform.position.y;
        float playerPositionZ = transform.position.z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPosition();
        }
        float inx = Input.GetAxis("Horizontal");
        if (playerPositionX>-2.5F&&inx<0)
        {
            transform.Translate(inx * translateSpeed * Time.deltaTime, 0, 0);
            //Vector3 newPosition = new Vector3(playerPositionX - 2.5F, playerPositionY, playerPositionZ);
            //this.transform.position=newPosition;
        }
        if (inx> 0 && playerPositionX < 2.5f)
        {
            transform.Translate(inx * translateSpeed * Time.deltaTime, 0, 0);
        }
        // for mobile movement
        float inxAcceleration = Input.acceleration.x;
        if (playerPositionX > -2.5F && inxAcceleration < 0)
        {
            transform.Translate(inxAcceleration * translateSpeed * Time.deltaTime, 0, 0);
            //Vector3 newPosition = new Vector3(playerPositionX - 2.5F, playerPositionY, playerPositionZ);
            //this.transform.position=newPosition;
        }
        if (inxAcceleration > 0 && playerPositionX < 2.5f)
        {
            transform.Translate(inxAcceleration * translateSpeed * Time.deltaTime, 0, 0);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenPill"))
        {
            if (other.gameObject.transform.position.y < 5.0f)
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == green)
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();

                }
                else
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();

                }
            }
            else
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == green)
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();

                }
                else
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();

                }
            }
           scoreText.text = "Score :" + score;
            // GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("RedPill"))
        {
            if (other.gameObject.transform.position.y < 5.0f)
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == red)
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();
                }
                else
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();

                }
            }
            else
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == red)
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();

                }
                else
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();

                }
            }
              scoreText.text = "Score :" + score;

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BluePill"))
        {
            if (other.gameObject.transform.position.y < 5.0f)
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == blue)
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();


                }
                else
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();

                }
            }
            else
            {
                if (gameObject.GetComponent<Renderer>().sharedMaterial == blue)
                {
                    score -= 5;
                    badHit.GetComponent<AudioSource>().Play();


                }
                else
                {
                    score += 10;
                    goodHit.GetComponent<AudioSource>().Play();

                }
            }
            scoreText.text = "Score :" + score;
            // GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Obstacle2") || other.gameObject.CompareTag("Obstacle3"))
        {
            health--;
             healthText.text = "Health :" + health;
            obstacleHit.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }

    }
    public int getScore()
    {
        return score;
    }
    public int getHealth()
    {
        return health;
    }
    public void setScore()
    {
        score = 0;
        scoreText.text = "Score :" + score;
    }
    public void setHealth()
    {
        health = 3;
        healthText.text = "Health :" + health;
    }
    public void resetPosition()
    {
       
        Vector3 newPosition = new Vector3(0f, 1f, transform.position.z);
        this.transform.position=newPosition;

    }
    public void resetColorAndTimer()
    {
        gameObject.GetComponent<Renderer>().material = green;
        colorNumber = 1;
        timer = 0.0f;

    }
    private int GenerateRandomNumber()
    {
        var arlist = new ArrayList();
        arlist.Add(1);
        arlist.Add(2);
        arlist.Add(3);
        int num1 = ran.Next(0, arlist.Count);
        int generatedNumber = (int)arlist[num1];
        if (generatedNumber != colorNumber) return generatedNumber;
        arlist.RemoveAt(num1);
        return (int)arlist[ran.Next(0, arlist.Count)];
    }
    public void SwitchPosition()
    {
        float playerPositionX = transform.position.x;

        float playerPositionY = transform.position.y;
        float playerPositionZ = transform.position.z;
        if (playerPositionY < 5)
        {
            // player at plane one
            Vector3 newPosition = new Vector3(playerPositionX, 9.0F, playerPositionZ);
            this.transform.position = newPosition;
        }
        else
        {
            // player at plane two
            Vector3 newPosition = new Vector3(playerPositionX, 1.0F, playerPositionZ);
            this.transform.position = newPosition;

        }
        switchLevelMusic.GetComponent<AudioSource>().Play();

    }
}
