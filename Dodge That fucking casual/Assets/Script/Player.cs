using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    [SerializeField] GameObject[] objectList; // victoryDeathMenu, Life1, Life2, Life3
    [SerializeField] Events ev;
    [SerializeField] PlayerController playerC;


    void Start() {
        this.life = 3;   
    }

    void Update() {
        if(life >= 3) {
            life = 3;
            objectList[1].SetActive(true);
            objectList[2].SetActive(true);
            objectList[3].SetActive(true);
        }
        if(life == 2) {
            objectList[1].SetActive(false);
        }
        if(life == 1) {
            objectList[2].SetActive(false);
        }
        if(life <= 0) {
            life = 0;
            objectList[3].SetActive(false);
            Time.timeScale = 0f;
            ev.isInGame = false;
            objectList[0].SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("ball"))  // if ball touch a player, life-- & respawn
        {
            life--;
            if(playerC.isPlayer) {
                this.transform.position = new Vector3(-5, 0, 0);
            } else {
                this.transform.position = new Vector3(5, 0, 0);
            }
        }
    }
}
