using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class State
{
    public GameState gameState;
    public Vector3 lastBallPosition, ballPosition, player1CurrentPosition, player2CurrentPosition;
    public int stateResult;

    public State(GameState previousGameState, Vector3 lastBallPosition, Vector3 ballPosition, Vector3 player1CurrentPosition, Vector3 player2CurrentPosition)
    {
        this.lastBallPosition = lastBallPosition;
        this.ballPosition = ballPosition;
        this.player1CurrentPosition = player1CurrentPosition;
        this.player2CurrentPosition = player2CurrentPosition;
        stateResult = GameState.RESULT_NONE;

        //No previous moves game just started
        if (previousGameState != null)
        {
            this.lastBallPosition = ballPosition;
            this.ballPosition = BallMovement.ballPosition;
            this.player1CurrentPosition = PlayerController.p1Position;
            this.player1CurrentPosition = PlayerController.p2Position;
        }
        else
        {
            this.lastBallPosition = lastBallPosition;
            this.ballPosition = BallMovement.ballDefaultPosition;
            this.player1CurrentPosition = PlayerController.p1DefaultPosition;
            this.player2CurrentPosition = PlayerController.p2DefaultPosition;
        }
    }
}
