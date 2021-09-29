using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject smashAreaPlayer;
    [SerializeField] private Transform smashPointPlayer;
    private static Vector3 lastDirectionIntent;
    private static Vector3 lastDirectionIntent2;
    public static Vector3 p1Position;
    public static Vector3 p2Position;
    public static Vector3 p1DefaultPosition;
    public static Vector3 p2DefaultPosition;
    private float playerSpeed = 5f;
    private float playerSpeed = 5.5f;
    public bool isPlayer;

    public void Start()
    {
        if (isPlayer)
        {
            p1DefaultPosition = gameObject.transform.position;
        }
        else
        {
            p2DefaultPosition = gameObject.transform.position;
        }
    }

    void Update() {
        Movement();
        SmashDaBall();
        lastDirectionIntent = lastDirectionIntent.normalized;
        lastDirectionIntent2 = lastDirectionIntent2.normalized;
        if (isPlayer)
        {
            p1Position = gameObject.transform.position;
        }
        else
        {
            p2Position = gameObject.transform.position;
        }
    }

    private void FixedUpdate() {
        if(isPlayer) {
            gameObject.transform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
        } else {
            gameObject.transform.localPosition += lastDirectionIntent2 * (Time.deltaTime * playerSpeed);
        }
    }
    
    public void SmashDaBall()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Smash();
            }   
        }
        else 
        {
            if (!Events.isAI)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Smash();
                }      
            }
        }
    }
    
    private void Movement() {
        if (isPlayer) {
            if (Input.GetKey(KeyCode.Z)) {
                WalkToUpPlayer1();
            }
            if (Input.GetKey(KeyCode.Q)) {
                WalkToLeftPlayer1();
            }
            if (Input.GetKey(KeyCode.S)) {
                WalkToDownPlayer1();
            }
            if (Input.GetKey(KeyCode.D)) {
                WalkToRightPlayer1();
            }
        } else {
            if (!Events.isAI)
            {
                if (Input.GetKey(KeyCode.UpArrow)) {
                    WalkToUpPlayer2();
                }
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    WalkToLeftPlayer2();
                }
                if (Input.GetKey(KeyCode.DownArrow)) {
                    WalkToDownPlayer2();
                }
                if (Input.GetKey(KeyCode.RightArrow)) {
                    WalkToRightPlayer2();
                }
            }
        }
    }
    
    public void WalkToUpPlayer1()
    {
        this.transform.position +=  Vector3.up * playerSpeed * Time.deltaTime;
    }
    
    public  void WalkToLeftPlayer1() {
        this.transform.position +=  Vector3.left * playerSpeed * Time.deltaTime;
    }
    
    public void WalkToDownPlayer1() {
        this.transform.position +=  Vector3.down * playerSpeed * Time.deltaTime;
    }
    
    public void WalkToRightPlayer1() {
        this.transform.position +=  Vector3.right * playerSpeed * Time.deltaTime;
    }

    public void WalkToUpPlayer2(float timeCall = 0)
    {
        if (timeCall == 0)
        {
            this.transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        else
        {
            
            for (int i = 0; i < timeCall; i++)
            {
                this.transform.position += Vector3.up * playerSpeed * Time.deltaTime;
            }
        }
    }

    public  void WalkToLeftPlayer2(float timeCall = 0) {
        if (timeCall == 0)
        {
            this.transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < timeCall; i++)
            {
                this.transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            }   
        }
    }

    public void WalkToDownPlayer2(float timeCall = 0) {
        if (timeCall == 0)
        {
            this.transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < timeCall; i++)
            {
                this.transform.position += Vector3.down * playerSpeed * Time.deltaTime;
            }   
        }
    }

    public void WalkToRightPlayer2(float timeCall = 0) {
        if (timeCall == 0)
        {
            this.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < timeCall; i++)
            {
                this.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            }   
        }
    }

    public void Smash()
    {
        GameObject smash = Instantiate(smashAreaPlayer, smashPointPlayer.position, Quaternion.identity);
        Destroy(smash, 0.3f);   
    }

}
