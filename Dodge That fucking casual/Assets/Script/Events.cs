using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;
    public static bool isAI;
    private int i = 0;

    public void Start() {
        InvokeRepeating("EventXSeconds", 10.0f, 10.0f);
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
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
