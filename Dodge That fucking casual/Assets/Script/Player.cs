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


    void Start()
    {
        life = 3;   
    }

    void Update()
    {
        if(life >= 3) {
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
            victoryDeathMenu.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            life--;
            this.transform.position = new Vector2(0,0);
        }
    }
}
