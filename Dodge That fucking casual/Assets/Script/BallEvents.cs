using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private void Start()
    {
        Instantiate(ball, ball.transform.position, Quaternion.identity);
    }
}
