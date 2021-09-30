using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Smash values
    [SerializeField] private GameObject smashAreaPlayer;
    [SerializeField] private Transform smashPointPlayer;
    
    //Movement values
    private Vector3 lastDirectionIntent;
    private Vector3 lastDirectionIntent2;
    public float playerSpeed = 5.5f;
    public bool isPlayer;

    void Update() {
        GetMovement(isPlayer);
        SmashDaBall();
        lastDirectionIntent2.Normalize();
        lastDirectionIntent.Normalize();
    }

    private void FixedUpdate() {
        //Move Player1 or Player2
        if(isPlayer) {
            gameObject.transform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
        } else {
            gameObject.transform.localPosition += lastDirectionIntent2 * (Time.deltaTime * playerSpeed);
        }
    }

    private void SmashDaBall()
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
    
    private void GetMovement(bool player) {
        if (player) {
            if (Input.GetKey(KeyCode.Z)) {
                WalkPlayer(player, Vector3.up);
            }
            if (Input.GetKey(KeyCode.Q)) {
                WalkPlayer(player, Vector3.left);
            }
            if (Input.GetKey(KeyCode.S)) {
                WalkPlayer(player, Vector3.down);
            }
            if (Input.GetKey(KeyCode.D)) {
                WalkPlayer(player, Vector3.right);
            }
            if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {
                lastDirectionIntent = Vector3.zero;
            }   
        } else {
            if (!Events.isAI)
            {
                if (Input.GetKey(KeyCode.UpArrow)) {
                    WalkPlayer(player, Vector3.up);
                }
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    WalkPlayer(player, Vector3.left);
                }
                if (Input.GetKey(KeyCode.DownArrow)) {
                    WalkPlayer(player, Vector3.down);
                }
                if (Input.GetKey(KeyCode.RightArrow)) {
                    WalkPlayer(player, Vector3.right);
                }
            }
            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow)) {
                lastDirectionIntent2 = Vector3.zero;
            }   
        }
    }

    public Vector3 WalkPlayer(bool player, Vector3 direction, float timeCall = 0)
    {
        if (player)
        {
            if (timeCall == 0)
            {
                lastDirectionIntent += direction * playerSpeed * Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < timeCall; i++)
                {
                    lastDirectionIntent += direction * playerSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (timeCall == 0)
            {
                lastDirectionIntent2 += direction * playerSpeed * Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < timeCall; i++)
                {
                    lastDirectionIntent2 += direction * playerSpeed * Time.deltaTime;
                }
            }
            
        }
        return gameObject.transform.position;
    }

    public void Smash()
    {
        //Instantiate prefab to make the ball bounce on it
        GameObject smash = Instantiate(smashAreaPlayer, smashPointPlayer.position, Quaternion.identity);
        //Destroy it soon after
        Destroy(smash, 0.3f);
    }

}
