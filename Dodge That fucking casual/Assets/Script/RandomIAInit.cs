using System;
using System.Collections;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomIAInit : MonoBehaviour
{
    //Player to be controlled values
    [SerializeField] private PlayerController playerAI;

    //Random action values
    private int randomAction;
    private float actionCooldown;
    private float randomActionTime;
    private float smashCooldown;

    private void Update()
    {
        if (Events.isAI)
        {
            //Can do an action after the timer is 0
            actionCooldown -= Time.deltaTime;
            if (actionCooldown <= 0)
            {
                actionCooldown = 0.001f;
                RandomAction();   
            }   
        }
    }

    //Do a random action
    private void RandomAction()
    {
        randomAction = Random.Range(0, 5);
        randomActionTime = Random.Range(10, 30);
        switch (randomAction)
        {
            case 0:
                playerAI.WalkPlayer(false, Vector3.up, randomActionTime);
                break;
            case 1:
                playerAI.WalkPlayer(false, Vector3.down, randomActionTime);
                break;
            case 2:
                playerAI.WalkPlayer(false, Vector3.left, randomActionTime);
                break;
            case 3:
                playerAI.WalkPlayer(false, Vector3.right, randomActionTime);
                break;
            case 4:
                smashCooldown -= Time.deltaTime;
                if (smashCooldown <= 0)
                {
                    smashCooldown = 0.2f;
                    playerAI.Smash();   
                }
                break;
        }
    }
}
