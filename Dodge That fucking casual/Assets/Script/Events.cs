using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject[] objectList; // pauseMenu, player1, player2, vicMenuJ1, vicMenuJ2, menu, message, timer
    private Player lifePlayer;
    private PlayerController playerController;
    private BallMovement ballVel;
    private TextMeshProUGUI messageText;
    private TextMeshProUGUI timerText;
    private GameObject[] ball;
    public bool isPaused;
    public bool isInGame;
    private float timers;
    public static bool isAI;
    private int i = 0;

    public void Start() {
        BallMovement.isPlaying = false;
        BallMovement.isPlayingSimu = false;
        InvokeRepeating("EventXSeconds", 15.0f, 15.0f);
        Time.timeScale = 0f;
        isAI = false;
        messageText = objectList[6].GetComponent<TextMeshProUGUI>();
        timerText = objectList[7].GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        ChangeGameMode();
        if(Input.GetKeyDown(KeyCode.Escape)) { //check if game is launched to use pause menu
            if(isPaused) {
                Pause(false, 1f);
            } else {
                if(isInGame) {
                    Pause(true, 0f);
                }
            }
        }

        if(isInGame) {
            timerText = objectList[7].GetComponent<TextMeshProUGUI>();
            timers += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timers / 60F);
	        int seconds = Mathf.FloorToInt(timers % 60F);
	        int milliseconds = Mathf.FloorToInt((timers * 100F) % 100F);
	        timerText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00"));
        }
    }

    public void EventXSeconds() { //all possible events, +- ball velocity, +- players velocity & + life players
        if(isInGame == true) {
            i++;
            int chance = Random.Range(1, 100);
            if(chance <= 20) {
                messageText.SetText("MALUS : SPEEDBALL");
                ChangeBallVelocity(10f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 21 && chance <= 40) { // 20%
                messageText.SetText("BONUS : SLOWBALL");
                ChangeBallVelocity(1f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 41 && chance <= 60) {
                messageText.SetText("BONUS : SPEEDBOOST");
                ChangePlayerVelocity(objectList[1], 8f);
                ChangePlayerVelocity(objectList[2], 8f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 61 && chance <= 80) {
                messageText.SetText("MALUS : SLOWBOOST");
                ChangePlayerVelocity(objectList[1], 3f);
                ChangePlayerVelocity(objectList[2], 3f);
                Invoke("ResetBonusMalus", 10.0f);
            }  else if(chance > 96 && chance <= 100) { // 5% 
                messageText.SetText("BONUS : LIFE");
                ChangeLifePlayer(objectList[1], 1);
                ChangeLifePlayer(objectList[2], 1);
                Invoke("ResetBonusMalus", 10.0f);
            }
        }
    }

    private void ResetBonusMalus() {
        messageText.SetText("");
        ChangeBallVelocity(5f);
        ChangePlayerVelocity(objectList[1], 5.5f);
        ChangePlayerVelocity(objectList[2], 5.5f);
    }

    private void ChangeBallVelocity(float vel) {
        ball = GameObject.FindGameObjectsWithTag("ball");
        ballVel = ball[0].GetComponent<BallMovement>();
        ballVel.ballSpeed = vel;
    }

    private void ChangePlayerVelocity(GameObject obj, float vel) {
        playerController = obj.GetComponent<PlayerController>();
        playerController.playerSpeed = vel;
    }

    private void ChangeLifePlayer(GameObject obj, int health) {
        lifePlayer = obj.GetComponent<Player>();
        lifePlayer.life += health;
    }

    public void Pause(bool b, float t) {
        objectList[0].SetActive(b);
        Time.timeScale = t; 
        isPaused = b;
    }

    public void Restart() { //restart a party 
        objectList[1].transform.position = new Vector3(-5, 0, 0); //respawn
        objectList[2].transform.position = new Vector3(5, 0, 0);
        ChangeLifePlayer(objectList[1], 3); //reset lifes
        ChangeLifePlayer(objectList[2], 3);
        objectList[3].SetActive(false);
        objectList[4].SetActive(false);
        objectList[5].SetActive(false);
        messageText.SetText("");
        Time.timeScale = 1f;
        isInGame = true;
        timers = 0;
        i = 0;
        ball = GameObject.FindGameObjectsWithTag("ball");
        ball[0].transform.position = new Vector3(0, -3, 0);
        ballVel = ball[0].GetComponent<BallMovement>();
        ballVel.ballSpeed = 5f;
    }

    public void ChangeGameMode()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (isAI)
            {
                isAI = false;
            }
            else
            {
                isAI = true;
            }
        }
    }
}
