using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class CameraSwitch : MonoBehaviour
{
    GameObject player;
    Player playerLogic;
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject optionPanel;
    public GameObject pausePanel;

    public GameObject goodHit;
    public GameObject badHit;
    public GameObject switchLevel;
    public GameObject obstacleHit;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    private int camPosition=0;
    private bool gameIsPaused = true;
    private int playerHealth;
    public Text muteText;
    private bool muteBoolean=false;

    void Start()
    {
        //Get Camera Listeners
        player = GameObject.Find("Player");
        playerLogic = player.GetComponent<Player>();
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraPositionChange();
        Time.timeScale = 0f;
        playerLogic.GetComponent<AudioSource>().Stop();
    }
    void Update()
    {
        playerHealth = playerLogic.getHealth();
        if (playerHealth == 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        switchCamera();

    }
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraPositionChange();
        }
    }
    //Camera change Logic
    public void cameraPositionChange()
    {        
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;
            cameraTwoAudioLis.enabled = false;

            cameraTwo.SetActive(false);
            camPosition = 1;
        }
       else if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);
            camPosition = 0;
        }

    }
   public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            playerLogic.GetComponent<AudioSource>().Stop();

            pausePanel.SetActive(true);


        }
        else
        {
            Time.timeScale = 1;
            playerLogic.GetComponent<AudioSource>().Play();
            pausePanel.SetActive(false);

        }
    }
    public void StartGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        startPanel.SetActive(false);
        playerLogic.GetComponent<AudioSource>().Play();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        UnityEngine.Debug.Log("EndGame");

        playerLogic.GetComponent<AudioSource>().Stop();

        gameIsPaused = true;
        endPanel.SetActive(true);

    }
    public void RestartGame()
    {

        gameIsPaused = false;
        camPosition = 0;
        playerLogic.setScore();
        playerLogic.setHealth();
        playerLogic.resetPosition();
        playerLogic.resetColorAndTimer();
        cameraPositionChange();
        DestroyAllObjects();
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        playerLogic.GetComponent<AudioSource>().Play(0);

    }
    public void DestroyAllObjects()
    {
        DestroyObstacle();
        DestroyObstacle2();
        DestroyObstacle3();
        DestroyRedCollectible();
        DestroyGreenCollectible();
        DestroyBlueCollectible();

    }
    private void DestroyObstacle()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle"))
            Destroy(obj);
    }
    private void DestroyObstacle2()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle2"))
            Destroy(obj);
    }
    private void DestroyObstacle3()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle3"))
            Destroy(obj);
    }
    private void DestroyRedCollectible()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("RedPill"))
            Destroy(obj);
    }
    private void DestroyGreenCollectible()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GreenPill"))
            Destroy(obj);
    }
    private void DestroyBlueCollectible()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("BluePill"))
            Destroy(obj);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        // back from option panel to start panel
        startPanel.SetActive(true);
        optionPanel.SetActive(false);

    }
    public void MuteButton()
    {
        if (muteBoolean==false)
        {
            muteText.text = "Unmute";
            startPanel.GetComponent<AudioSource>().volume = 0;
            optionPanel.GetComponent<AudioSource>().volume = 0;
            endPanel.GetComponent<AudioSource>().volume = 0;
            pausePanel.GetComponent<AudioSource>().volume = 0;
            playerLogic.GetComponent<AudioSource>().volume = 0;

            goodHit.GetComponent<AudioSource>().volume = 0;
            badHit.GetComponent<AudioSource>().volume = 0;
            switchLevel.GetComponent<AudioSource>().volume = 0;
            obstacleHit.GetComponent<AudioSource>().volume = 0;



        }
        else
        {
            muteText.text = "Mute";
            startPanel.GetComponent<AudioSource>().volume = 1;
            optionPanel.GetComponent<AudioSource>().volume = 1;
            endPanel.GetComponent<AudioSource>().volume = 1;
            pausePanel.GetComponent<AudioSource>().volume = 1;
            playerLogic.GetComponent<AudioSource>().volume = 1;


            goodHit.GetComponent<AudioSource>().volume = 1;
            badHit.GetComponent<AudioSource>().volume = 1;
            switchLevel.GetComponent<AudioSource>().volume = 1;
            obstacleHit.GetComponent<AudioSource>().volume = 1;






        }
        muteBoolean = !muteBoolean;
    }
    public void OptionButton()
    {
        // option panel
        startPanel.SetActive(false);
        optionPanel.SetActive(true);
    }
}
