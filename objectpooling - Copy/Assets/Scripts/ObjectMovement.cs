using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private float despawnDistance = -65f;
    public int z = 1;
    GameObject player;
    Player playerLogic;
    private int playerScore=0;
    private float constantSpeed = 15f;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("Player");
        playerLogic = player.GetComponent<Player>();
    }
    void Update()
    {
        playerScore = playerLogic.getScore();
        int rate = (playerScore / 50) +1;
        if (rate>1)
        {
            speed =constantSpeed *rate;
        }
        else
        {
            speed = constantSpeed;
        }
      //  UnityEngine.Debug.Log("Speed  :"+speed + " rate : "+rate);
        transform.position += (-transform.forward * speed * Time.deltaTime)*z;
        if (transform.position.z < despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
