using System;
using System.Collections;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomIAInit : MonoBehaviour
{
    [SerializeField] private PlayerController playerAI;
    private int randomAction;

    private float actionCooldown;
    private float randomActionTime;
    private float smashCooldown;

    private void Update()
    {
        if (Events.isAI)
        {
            actionCooldown -= Time.deltaTime;
            if (actionCooldown <= 0)
            {
                actionCooldown = 0.001f;
                RandomAction();   
            }   
        }
    }

    private void RandomAction()
    {
        randomAction = Random.Range(0, 5);
        randomActionTime = Random.Range(10, 30);
        //randomAction = 0;
        switch (randomAction)
        {
            case 0:
                playerAI.WalkToUpPlayer2(randomActionTime);
                break;
            case 1:
                playerAI.WalkToDownPlayer2(randomActionTime);
                break;
            case 2:
                playerAI.WalkToLeftPlayer2(randomActionTime);
                break;
            case 3:
                playerAI.WalkToRightPlayer2(randomActionTime);
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
