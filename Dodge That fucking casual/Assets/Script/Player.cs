using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject victoryDeathMenu;


    void Start()
    {
        life = 3;   
    }

    void Update()
    {
        if(life <= 0) {
            life = 0;
            Time.timeScale = 0f;
            victoryDeathMenu.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            life--;
            Debug.Log(life);
            this.transform.position = new Vector2(0,0);
        }
    }
}
