using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;
    private int i = 0;

    public void Start() {
        InvokeRepeating("EventXSeconds", 10.0f, 10.0f);
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }
}
