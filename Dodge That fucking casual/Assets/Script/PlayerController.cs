using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static Vector3 lastDirectionIntent;
    private static Vector3 lastDirectionIntent2;
    private float playerSpeed = 4;
    public bool isPlayer;

    void Update() {
        Movement(isPlayer);
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
    
    private void Movement(bool isPlayer) {
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
    
    private void WalkToUpPlayer1() {
        lastDirectionIntent +=  Vector3.up;
    }

    private void WalkToUpPlayer2() {
        lastDirectionIntent2 +=  Vector3.up;
    }

    private void WalkToLeftPlayer1() {
        lastDirectionIntent +=  Vector3.left;
    }

    private void WalkToLeftPlayer2() {
        lastDirectionIntent2 +=  Vector3.left;
    }
    
    private void WalkToDownPlayer1() {
        lastDirectionIntent +=  Vector3.down;
    }

    private void WalkToDownPlayer2() {
        lastDirectionIntent2 +=  Vector3.down;
    }
    
    private void WalkToRightPlayer1() {
        lastDirectionIntent +=  Vector3.right;
    }

    private void WalkToRightPlayer2() {
        lastDirectionIntent2 +=  Vector3.right;
    }
}
