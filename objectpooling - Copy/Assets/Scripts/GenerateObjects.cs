using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using UnityEngine;
public class GenerateObjects : MonoBehaviour
{
    GameObject player;
    Player playerLogic;
    int playerScore;
    public GameObject greenCollectible;
    public GameObject blueCollectible;
    public GameObject redCollectible;
    public GameObject obstacle;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public float rateOfGenerate = 2.0f;
    float timer = 0;
    public float obstacleSpawnDistance = 49.0f;
    public System.Random ran = new System.Random();


    void Start()
    {
        player = GameObject.Find("Player");
        playerLogic = player.GetComponent<Player>();
    }
    void Update()
    {
        playerScore = playerLogic.getScore();
        float scoreRate = ((playerScore / 50.0f) + 1.0f);
        timer = timer + Time.deltaTime;
 //       UnityEngine.Debug.Log("check : " + (timer >= rateOfGenerate/scoreRate)+"   " + rateOfGenerate / scoreRate);
        if (timer >=  rateOfGenerate/scoreRate)
        {
            SpawnObstacleAndCollectible(1.5f,1.0f);
            SpawnObstacleAndCollectible(8.5f,9.0f);

            timer = 0;

        }
    }

    public void SpawnObstacleAndCollectible(float y,float x)
    {
        int randomNumber = ran.Next(0, 16);
        if (randomNumber == 0)
        {
            createThreeObjects(y, x,"obstacle", "red", "green");
        }
        else if (randomNumber == 1)
        {
            createOneObject(y,x,"green");
        }
        else if (randomNumber == 2)
        {
            createOneObject(y,x,"obstacle");
        }
        else if (randomNumber == 3)
        {
            createOneObject(y,x,  "red");
        }
        else if (randomNumber == 4)
        {
            createTwoObjects(y,x, "red","green");
        }
        else if (randomNumber == 5)
        {
            createTwoObjects(y,x, "obstacle", "green");
        }
        else if (randomNumber == 6)
        {
            createTwoObjects(y,x, "obstacle", "red");
        }
        else if (randomNumber == 7)
        {
            createObstacle2(y,x);
        }
        else if (randomNumber == 8)
        {
            createObstacle3(y,x);
        }

        else if (randomNumber == 9)
        {
            createOneObject(y,x, "blue");
        }
        else if (randomNumber == 10)
        {
            createTwoObjects(y, x,"blue", "green");
        }
        else if (randomNumber == 11)
        {
            createTwoObjects(y, x ,"blue", "red");
        }
        else if (randomNumber == 12)
        {
            createTwoObjects(y,x, "obstacle", "blue");
        }
        else if (randomNumber == 13)
        {
            createThreeObjects(y, x,"blue", "red", "green");
        }
        else if (randomNumber == 14)
        {
            createThreeObjects(y, x, "obstacle","blue", "green");

        }
        else if (randomNumber == 15)
        {
            createThreeObjects(y,x ,"obstacle", "blue", "red");
        }

    }
    private float getOneRandomNumber()
    {
        var arlist = new ArrayList();
        arlist.Add(0.0f);
        arlist.Add(2.5f);
        arlist.Add(-2.5f);
        int num1 = ran.Next(0, arlist.Count);
        return (float)arlist[num1];

    }
    private ArrayList getTwoRandomNumber()
    {
        var outputArlist = new ArrayList();
        var arlist = new ArrayList();
        arlist.Add(0.0f);
        arlist.Add(2.5f);
        arlist.Add(-2.5f);
        int num1 = ran.Next(0, arlist.Count);
        outputArlist.Add(arlist[num1]);
        arlist.RemoveAt(num1);
        int num2 = ran.Next(0, arlist.Count);
        outputArlist.Add(arlist[num2]);
        return outputArlist;
    }
    //private void createGreenRedObstacle(float y)
    //{
    //    var arlist = new ArrayList();
    //    arlist.Add(0.0f);
    //    arlist.Add(2.5f);
    //    arlist.Add(-2.5f);
    //    int num1 = ran.Next(0, arlist.Count);
    //    float obsX = (float)arlist[num1];
    //    arlist.RemoveAt(num1);

    //    int num2 = ran.Next(0, arlist.Count);
    //    float redX = (float)arlist[num2];
    //    arlist.RemoveAt(num2);
    //    float greenX = (float)arlist[0];

    //    Instantiate(obstacle, new Vector3(obsX, 10.5f-y, obstacleSpawnDistance), Quaternion.identity);
    //    Instantiate(greenCollectible, new Vector3(redX, 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
    //    Instantiate(redCollectible, new Vector3(greenX, 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
       
    //}
    //private void createOneGreen(float y)
    //{
    //    float greenX = getOneRandomNumber();
    //    Instantiate(greenCollectible, new Vector3(greenX, 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
    //}
    //private void createOneRed(float y)
    //{
    //    float redX = getOneRandomNumber();
    //    Instantiate(redCollectible, new Vector3(redX, 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
    //}
    //private void createOneObstacle(float y)
    //{
    //    float obstacleX = getOneRandomNumber();
    //   Instantiate(obstacle, new Vector3(obstacleX, 10.5f-y, obstacleSpawnDistance), Quaternion.identity);
      

    //}
    //private void createGreenRed(float y)
    //{
    //    var arlist = getTwoRandomNumber();
    //    Instantiate(greenCollectible, new Vector3((float)arlist[0], 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
    //    Instantiate(redCollectible, new Vector3((float)arlist[1], 11.0f-y, obstacleSpawnDistance), Quaternion.identity);

    //}
    //private void createGreenObstacle(float y)
    //{
    //    var arlist = getTwoRandomNumber();
    //    Instantiate(greenCollectible, new Vector3((float)arlist[0], 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
    //    Instantiate(obstacle, new Vector3((float)arlist[1], 10.5f-y, obstacleSpawnDistance), Quaternion.identity);
    

    //}
    //private void createRedObstacle(float y)
    //{
    //    var arlist = getTwoRandomNumber();
    //     Instantiate(redCollectible, new Vector3((float)arlist[0], 11.0f-y, obstacleSpawnDistance), Quaternion.identity);
 
    //     Instantiate(obstacle, new Vector3((float)arlist[1], 10.5f-y, obstacleSpawnDistance), Quaternion.identity);
       

    //}
    private void createObstacle2(float y,float x)
    {
        var arlist = new ArrayList();
        arlist.Add(-1.0f);
        arlist.Add(1.85f);
        int num1 = ran.Next(0, arlist.Count);
        float obsX = (float)arlist[num1];
        Instantiate(obstacle2, new Vector3(obsX, x, obstacleSpawnDistance), Quaternion.identity);

    }
    private void createObstacle3(float y,float x)
    {
         Instantiate(obstacle3, new Vector3(0, x, obstacleSpawnDistance), Quaternion.identity);
       
    }

    // create One Object 
    private void createOneObject(float y,float x,string gameObject)
    {
        float locationX = getOneRandomNumber();
        if (gameObject == "red")
            Instantiate(redCollectible, new Vector3(locationX, y, obstacleSpawnDistance), Quaternion.identity);
        else
        if (gameObject == "blue")
            Instantiate(blueCollectible, new Vector3(locationX,  y, obstacleSpawnDistance), Quaternion.identity);
        else
        if (gameObject == "obstacle")
            Instantiate(obstacle, new Vector3(locationX,x, obstacleSpawnDistance), Quaternion.identity);
        else
        if (gameObject == "green")
            Instantiate(greenCollectible, new Vector3(locationX, y, obstacleSpawnDistance), Quaternion.identity);
    }

    private void createTwoObjects(float y,float x,string objectOne,string objectTwo)
    {
        var arlist = getTwoRandomNumber();

        if(objectOne=="red")
            Instantiate(redCollectible, new Vector3((float)arlist[0],  y , obstacleSpawnDistance), Quaternion.identity);
        if (objectOne == "blue")
            Instantiate(blueCollectible, new Vector3((float)arlist[0],  y , obstacleSpawnDistance), Quaternion.identity);
        if (objectOne == "obstacle")
            Instantiate(obstacle, new Vector3((float)arlist[0], x , obstacleSpawnDistance), Quaternion.identity);

        if (objectTwo == "red")
            Instantiate(redCollectible, new Vector3((float)arlist[1],  y , obstacleSpawnDistance), Quaternion.identity);
        if (objectTwo == "blue")
            Instantiate(blueCollectible, new Vector3((float)arlist[1], y , obstacleSpawnDistance), Quaternion.identity);
        if (objectTwo == "green")
            Instantiate(greenCollectible, new Vector3((float)arlist[1],  y , obstacleSpawnDistance), Quaternion.identity);



    }
    private void createThreeObjects(float y,float x,string objectOne, string objectTwo, string objectThree)
    {
        var arlist = new ArrayList();
        arlist.Add(0.0f);
        arlist.Add(2.5f);
        arlist.Add(-2.5f);
        int num1 = ran.Next(0, arlist.Count);
        float obsX = (float)arlist[num1];
        arlist.RemoveAt(num1);

        int num2 = ran.Next(0, arlist.Count);
        float redX = (float)arlist[num2];
        arlist.RemoveAt(num2);
        float greenX = (float)arlist[0];
        if (objectOne=="blue")
            Instantiate(blueCollectible, new Vector3(obsX, y , obstacleSpawnDistance), Quaternion.identity);
        if (objectOne == "obstacle")
            Instantiate(obstacle, new Vector3(obsX,x, obstacleSpawnDistance), Quaternion.identity);
        if(objectTwo=="red")
            Instantiate(redCollectible, new Vector3(redX,  y, obstacleSpawnDistance), Quaternion.identity);
        if (objectTwo == "blue")
            Instantiate(blueCollectible, new Vector3(redX,  y, obstacleSpawnDistance), Quaternion.identity);
        if (objectThree == "red")
            Instantiate(redCollectible, new Vector3(greenX,  y, obstacleSpawnDistance), Quaternion.identity);
        if (objectThree == "green")
            Instantiate(greenCollectible, new Vector3(greenX,  y, obstacleSpawnDistance), Quaternion.identity);
    }



}
