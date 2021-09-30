using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    [SerializeField] GameObject victoryDeathMenu;
    [SerializeField] GameObject Life1;
    [SerializeField] GameObject Life2;
    [SerializeField] GameObject Life3;
    [SerializeField] Events ev;
    [SerializeField] PlayerController playerC;


    void Start()
    {
        life = 3;   
    }

    void Update()
    {
        if(life >= 3) {
            life = 3;
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
        }
        if(life == 2) {
            Life1.SetActive(false);
        }
        if(life == 1) {
            Life2.SetActive(false);
        }
        if(life <= 0) {
            life = 0;
            Life3.SetActive(false);
            Time.timeScale = 0f;
            ev.isInGame = false;
            victoryDeathMenu.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
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
