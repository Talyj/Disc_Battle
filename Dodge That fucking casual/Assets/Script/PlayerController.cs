using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject smashAreaPlayer;
    [SerializeField] private Transform smashPointPlayer;
    private static Vector3 lastDirectionIntent;
    private static Vector3 lastDirectionIntent2;
    private float playerSpeed = 5f;
    public bool isPlayer;

    void Update() {
        Movement();
        SmashDaBall();
        lastDirectionIntent = lastDirectionIntent.normalized;
        lastDirectionIntent2 = lastDirectionIntent2.normalized;
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Smash();
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
            if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {
                lastDirectionIntent = Vector3.zero;
            }
        } else {
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
            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow)) {
                lastDirectionIntent2 = Vector3.zero;
            }
        }
    }
    
    public void WalkToUpPlayer1()
    {
        lastDirectionIntent +=  Vector3.up * playerSpeed * Time.deltaTime;
    }
    
    public  void WalkToLeftPlayer1() {
        lastDirectionIntent +=  Vector3.left * playerSpeed * Time.deltaTime;
    }
    
    public void WalkToDownPlayer1() {
        lastDirectionIntent +=  Vector3.down * playerSpeed * Time.deltaTime;
    }
    
    public void WalkToRightPlayer1() {
        lastDirectionIntent +=  Vector3.right * playerSpeed * Time.deltaTime;
    }

    public void WalkToUpPlayer2(float timeCall = 0) {
        for (int i = 0; i < timeCall; i++)
        {
            lastDirectionIntent2 +=  Vector3.up * playerSpeed * Time.deltaTime;
        }
    }

    public  void WalkToLeftPlayer2(float timeCall = 0) {
        for (int i = 0; i < timeCall; i++)
        {
            lastDirectionIntent2 += Vector3.left * playerSpeed * Time.deltaTime;
        }
    }

    public void WalkToDownPlayer2(float timeCall = 0) {
        for (int i = 0; i < timeCall; i++)
        {
            lastDirectionIntent2 += Vector3.down * playerSpeed * Time.deltaTime;
        }
    }

    public void WalkToRightPlayer2(float timeCall = 0) {
        for (int i = 0; i < timeCall; i++)
        {
            lastDirectionIntent2 += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    public void Smash()
    {
        GameObject smash = Instantiate(smashAreaPlayer, smashPointPlayer.position, Quaternion.identity);
        Destroy(smash, 0.3f);   
    }

}
