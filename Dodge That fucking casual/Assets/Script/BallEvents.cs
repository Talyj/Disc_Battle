using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    public void SpawnBall() {   
        Instantiate(ball, ball.transform.position, Quaternion.identity);
    }
}
