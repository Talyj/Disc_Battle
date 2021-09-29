using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject victoryMenuJ1;
    [SerializeField] GameObject victoryMenuJ2;
    [SerializeField] GameObject Menu;
    private GameObject[] ball;
    public bool isPaused;
    public bool isInGame;
    public static bool isAI;
    private int i = 0;

    public void Start() {
        InvokeRepeating("EventXSeconds", 10.0f, 10.0f);
        BallMovement.isPlaying = false;
        BallMovement.isPlayingSimu = false;
        isAI = false;
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
    }

    public void EventXSeconds() {
        i++;
        Debug.Log("Evenement numéro " + i + " !");
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

    public void Restart()
    {
        BallMovement.speedBall = 5f;
        player1.transform.position = new Vector3(-5, 0, 0);
        player2.transform.position = new Vector3(5, 0, 0);
        Player lifePlayer1 = player1.GetComponent<Player>();
        Player lifePlayer2 = player2.GetComponent<Player>();
        lifePlayer1.life = 3;
        lifePlayer2.life = 3;
        victoryMenuJ1.SetActive(false);
        victoryMenuJ2.SetActive(false);
        Menu.SetActive(false);
        Time.timeScale = 1f;
        isInGame = true;
        ball = GameObject.FindGameObjectsWithTag("ball");
        ball[0].transform.position = new Vector3(0, -3, 0);
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
