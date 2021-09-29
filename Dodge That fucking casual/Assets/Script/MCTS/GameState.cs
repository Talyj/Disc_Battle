using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState
{
    public Vector3 ballPosition, playerPosition, player2Position;

    public const int RESULT_NONE = -1;
    public const int RESULT_DRAW = 0;
    public const int RESULT_P1 = 1;
    public const int RESULT_P2 = 2;
}
