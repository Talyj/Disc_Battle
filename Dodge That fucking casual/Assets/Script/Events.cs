using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject victoryMenuJ1;
    [SerializeField] GameObject victoryMenuJ2;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject message;
    [SerializeField] GameObject timer;
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
        messageText = message.GetComponent<TextMeshProUGUI>();
        timerText = timer.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        ChangeGameMode();
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        if(isInGame) {
            timerText = timer.GetComponent<TextMeshProUGUI>();
            timers += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timers / 60F);
	        int seconds = Mathf.FloorToInt(timers % 60F);
	        int milliseconds = Mathf.FloorToInt((timers * 100F) % 100F);
	        timerText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00"));
        }
    }

    public void EventXSeconds() {
        if(isInGame == true) {
            i++;
            int chance = Random.Range(1, 100);
            if(chance <= 20) {
                messageText.SetText("MALUS : SPEEDBALL");
                ChangeBallVelocity(15f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 21 && chance <= 40) { // 20%
                messageText.SetText("BONUS : SLOWBALL");
                ChangeBallVelocity(1f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 41 && chance <= 60) {
                messageText.SetText("BONUS : SPEEDBOOST");
                ChangePlayerVelocity(8f);
                Invoke("ResetBonusMalus", 10.0f);
            } else if(chance > 61 && chance <= 80) {
                messageText.SetText("MALUS : SLOWBOOST");
                ChangePlayerVelocity(3f);
                Invoke("ResetBonusMalus", 10.0f);
            }  else if(chance > 96 && chance <= 100) { // 5% 
                messageText.SetText("BONUS : LIFE");
                ChangeLifePlayer();
                Invoke("ResetBonusMalus", 10.0f);
            }
        }
    }

    private void ResetBonusMalus() {
        messageText.SetText("");
        ChangeBallVelocity(5f);
        ChangePlayerVelocity(5.5f);
    }

    private void ChangeBallVelocity(float vel) {
        ball = GameObject.FindGameObjectsWithTag("ball");
        BallMovement ballVel = ball[0].GetComponent<BallMovement>();
        ballVel.ballSpeed = vel;
    }

    private void ChangePlayerVelocity(float vel) {
        PlayerController playerVel1 = player1.GetComponent<PlayerController>();
        PlayerController playerVel2 = player2.GetComponent<PlayerController>();
        playerVel1.playerSpeed = vel;
        playerVel2.playerSpeed = vel;
    }

    private void ChangeLifePlayer() {
        Player lifePlayer1 = player1.GetComponent<Player>();
        Player lifePlayer2 = player2.GetComponent<Player>();
        lifePlayer1.life += 1;
        lifePlayer2.life += 1;
    }

    public void Pause() {
        if(isInGame == true) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart() {
        player1.transform.position = new Vector3(-5, 0, 0);
        player2.transform.position = new Vector3(5, 0, 0);
        Player lifePlayer1 = player1.GetComponent<Player>();
        Player lifePlayer2 = player2.GetComponent<Player>();
        lifePlayer1.life = 3;
        lifePlayer2.life = 3;
        victoryMenuJ1.SetActive(false);
        victoryMenuJ2.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 1f;
        isInGame = true;
        timers = 0;
        i = 0;
        ball = GameObject.FindGameObjectsWithTag("ball");
        ball[0].transform.position = new Vector3(0, -3, 0);
        BallMovement ballVel = ball[0].GetComponent<BallMovement>();
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
