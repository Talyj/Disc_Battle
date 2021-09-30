using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class MCTSIA : MonoBehaviour
{
    [SerializeField] private PlayerController p1;
    [SerializeField] private PlayerController p2;
    [SerializeField] private Collider[] wallsCollider;

    private GameObject ballPos;
    private Collider ballCollider;
    private Vector3 direction;
    private float speedBall;

    //Up, Down, Left, Right
    private Vector3[] actionsList = {
        new Vector3(0, 5, 0),
        new Vector3(0, -5, 0),
        new Vector3(-5, 0, 0),
        new Vector3(5, 0, 0),
    }; 

    private Vector3 p1PosSimuEnemy;
    private Vector3 p2PosSimu;
    private Vector3 BallPosSimu;
    // Start is called before the first frame update
    void Start()
    {
        InitActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (BallMovement.isPlayingSimu)
        {
            ballPos = GameObject.FindGameObjectWithTag("ball");
            ballCollider = ballPos.GetComponent<Collider>();
            Simulate();
            Debug.Log(p1PosSimuEnemy);
        }
    }

    private int Simulate()
    {
        var test = 0;
        p1PosSimuEnemy += ChooseRandomAction();
        p2PosSimu += ChooseRandomAction();
        BallPosSimu = BallAction();
        Debug.Log(BallPosSimu);
        return 0;
    }

    private void InitActions()
    {
        p1PosSimuEnemy = p1.transform.position;
        p2PosSimu = p2.transform.position;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        speedBall = 5f;
    }

    
    private Vector3 CheckBallCollision(Vector3 ballPos)
    {
        Vector3 newDirection = new Vector3(1, 1, 1);
        // In order : North, West, South, East
        if (ballPos.y + ballCollider.bounds.extents.y + 0.3 >= wallsCollider[0].bounds.min.y)
        {
            newDirection.y *= -1;
        }

        if (ballPos.x - ballCollider.bounds.extents.x <= wallsCollider[1].bounds.max.x)
        {
            newDirection.x *= -1;
        }
         
        if (ballPos.y - ballCollider.bounds.extents.y <= wallsCollider[2].bounds.max.y)
        {
            newDirection.y *= -1;
        }
         
        if (ballPos.x + ballCollider.bounds.extents.x  + 0.3 >= wallsCollider[3].bounds.min.x)
        {
            newDirection.x *= -1;
        }

        return newDirection;
    }
    
    private Vector3 BallAction()
    {
        Vector3 positionBall = new Vector3();
        positionBall += CheckBallCollision(positionBall) * (Time.deltaTime * speedBall);
        return positionBall;
    }
    
    private Vector3 ChooseRandomAction()
    {
        Vector3 positionPlayer = new Vector3();
        var actionId = Random.Range(0, 4);
        // actionId = 0;
        //0 = Up, 1 = Down, 2 = Left, 3 = Right
        switch (actionId)
        {
            case 0:
                positionPlayer = actionsList[0];
                break;
            case 1:
                positionPlayer = actionsList[1];
                break;
            case 2:
                positionPlayer = actionsList[2];
                break;
            case 3:
                positionPlayer = actionsList[3];
                break;
        }

        return positionPlayer;
    }
}
