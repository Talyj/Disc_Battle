using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public GameState gameState;
    public Point lastBallPosition, ballPosition, playerCurrentPosition;
    public int stateResult;

    public State(GameState previousGameState, Point lastBallPosition, Point ballPosition, Point playerCurrentPosition)
    {
        this.lastBallPosition = lastBallPosition;
        this.ballPosition = ballPosition;
        this.playerCurrentPosition = playerCurrentPosition;
        //stateResult =

        //No previous moves game just started
        if (previousGameState != null)
        {
            //Modify gameState
        }
        else
        {
            
        }
    }
}
