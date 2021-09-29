using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeNode : MonoBehaviour
{

    [SerializeField] private PlayerController p2;
    [SerializeField] private PlayerController p1;
    [SerializeField] private Collider[] wallsCollider;
    private Collider ballCollider;
    private GameObject ball;
    private Vector3 positionP1;
    private Vector3 positionSmashP1;
    private Vector3 positionP2;
    private Vector3 positionSmashP2;
    private Vector3 ballPosition;

    private float[] wallsLimit;

    static System.Random r = new System.Random();
    public static double epsilon = 1e-6;
    
    public List<TreeNode> children;
    public double nVisits, totValue;
    public double uctValue;

    private int randomActionTime;
    
    public State state;

    private bool oneTimeUse;


    public void Start()
    {
        positionP1 = p1.transform.position;
        positionP2 = p2.transform.position;
        oneTimeUse = true;
    }

    public void Update()
    {
        if (BallMovement.isPlayingSimu)
        {
            positionP1 = p1.transform.position;
            positionP2 = p2.transform.position;

            ball = GameObject.FindWithTag("ball");
            ballPosition = ball.transform.position;
            ballCollider = ball.gameObject.GetComponent<Collider>();

            var test = ballCollider.bounds.extents;
            if (oneTimeUse)
            {
                oneTimeUse = false;
                // DoRandomAction(p1, positionP1, positionSmashP1, ballPosition, BallMovement.direction,
                //     BallMovement.speedBall, p2, positionP2, positionSmashP2);
            }

            //var essai = CheckPointCollideWithBall(p1, ballPosition);
            //Simulate();
            //StartCoroutine(SimulateGame(p1, positionP1, positionSmashP1, ballPosition, BallMovement.direction,
            //BallMovement.speedBall, p2, positionP2, positionSmashP2));
        }
    }

    private bool CollideWithPlayer(double pointPosition, Collider collider)
    {
        if (pointPosition <= collider.bounds.max.y &&
            pointPosition >= collider.bounds.min.y &&
            pointPosition <= collider.bounds.max.x &&
            pointPosition >= collider.bounds.min.x)
        {
            return true;
            
        }
        
        return false;
    }
    
    private bool CheckPointCollideWithBall(PlayerController objectToTest, Vector3 ballPos)
    {
        var tempCollider = objectToTest.GetComponent<Collider>();
        if (CollideWithPlayer(ballPos.y + ballCollider.bounds.extents.y + 0.3, tempCollider) ||
            CollideWithPlayer(ballPos.x - ballCollider.bounds.extents.x, tempCollider) ||
            CollideWithPlayer(ballPos.y - ballCollider.bounds.extents.y, tempCollider) || 
            CollideWithPlayer(ballPos.x + ballCollider.bounds.extents.x + 0.3, tempCollider))
        {
            return true;
        }
        return false;
    }
    
    private string CheckBallCollision(Vector3 ballPos)
    {
        // In order : North, West, South, East
         if (ballPos.y + ballCollider.bounds.extents.y + 0.3 >= wallsCollider[0].bounds.min.y)
         {
             return "hor";
         }

         if (ballPos.x - ballCollider.bounds.extents.x <= wallsCollider[1].bounds.max.x)
         {
             return "ver";
         }
         
         if (ballPos.y - ballCollider.bounds.extents.y <= wallsCollider[2].bounds.max.y)
         {
             return "hor";
         }
         
         if (ballPos.x + ballCollider.bounds.extents.x  + 0.3 >= wallsCollider[3].bounds.min.x)
         {
             return "ver";
         }
        return "";
    }
    
    private double DoRandomAction(PlayerController player, Vector3 positionPlayer, Vector3 positionSmash, Vector3 ballPosition, Vector3 ballDirection, float speedBall, PlayerController enemyPlayer, Vector3 positionEnemyPlayer, Vector3 positionEnemySmash)
    {
        //while (BallMovement.isPlayingSimu)
        while (BallMovement.isPlayingSimu)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BallMovement.isPlayingSimu = false;
                break;
            }
            var actionId = Random.Range(0, 5);
            var actionId2 = Random.Range(0, 5);
            if (actionId != 4)
            {
                randomActionTime = Random.Range(10, 30);
            }
            // actionId = 0;
            switch (actionId)
            {
                case 0:
                    positionPlayer += player.WalkToUpPlayer1(randomActionTime);
                    positionSmash += player.WalkToUpPlayer1(randomActionTime);
                    break;
                case 1:
                    positionPlayer += player.WalkToDownPlayer1(randomActionTime);
                    positionSmash += player.WalkToDownPlayer1(randomActionTime);
                    break;
                case 2:
                    positionPlayer += player.WalkToLeftPlayer1(randomActionTime);
                    positionSmash += player.WalkToLeftPlayer1(randomActionTime);
                    break;
                case 3:
                    positionPlayer += player.WalkToRightPlayer1(randomActionTime);
                    positionSmash += player.WalkToRightPlayer1(randomActionTime);
                    break;
                case 4:
                    positionSmash = player.Smash();
                    break;
            }
            
            switch (actionId2)
            {
                case 0:
                    positionEnemyPlayer += enemyPlayer.WalkToUpPlayer1(randomActionTime);
                    positionEnemySmash += enemyPlayer.WalkToUpPlayer1(randomActionTime);
                    break;
                case 1:
                    positionEnemyPlayer += enemyPlayer.WalkToDownPlayer1(randomActionTime);
                    positionEnemySmash += enemyPlayer.WalkToDownPlayer1(randomActionTime);
                    break;
                case 2:
                    positionEnemyPlayer += enemyPlayer.WalkToLeftPlayer1(randomActionTime);
                    positionEnemySmash += enemyPlayer.WalkToLeftPlayer1(randomActionTime);
                    break;
                case 3:
                    positionEnemyPlayer += enemyPlayer.WalkToRightPlayer1(randomActionTime);
                    positionEnemySmash += enemyPlayer.WalkToRightPlayer1(randomActionTime);
                    break;
                case 4:
                    positionEnemySmash = enemyPlayer.Smash();
                    break;
            }

            ballPosition += ballDirection * (Time.deltaTime * speedBall);

            if (CheckBallCollision(ballPosition) == "hor")
            {
                ballDirection.y *= -1;
            }
            if (CheckBallCollision(ballPosition) == "ver")
            {
                ballDirection.x *= -1;
            }
            Debug.Log(ballPosition);
            if (actionId == 4)
            {
                //Check collision ball with smash
            }

            //Check if positionPlayer collide with the ball
            if (CheckPointCollideWithBall(p1, ballPosition))
            {
                Debug.Log("Ekip");
                BallMovement.isPlayingSimu = false;
            }
        }
        return 0.0;
    }

    private bool IsWin()
    {
        if (!BallMovement.isPlaying)
        {
            return true;
        }
        return false;
    }

    public int Simulate()
    {
        return 0;
    }

    public TreeNode(State state)
    {
        children = new List<TreeNode>();
        nVisits = 0;
        totValue = 0;

        this.state = state;
    }

    public void IterateMTCS()
    {
        LinkedList<TreeNode> visited = new LinkedList<TreeNode>();
        TreeNode cur = this;
        visited.AddLast(this);
        while (!cur.IsLeaf()) //1. SELECTION
        {
            cur = cur.Select();

            visited.AddLast(cur);
        }
        if (cur.state.stateResult == GameState.RESULT_NONE)
        {
            /*cur.expand(); //2. EXPANSION
            TreeNode newNode = cur.select();
            visited.AddLast(newNode);
            double value = newNode.simulate(); //3. SIMULATION

            foreach (TreeNode node in visited)
            {
                node.updateStats(value); //4. BACKPROPAGATION
            }*/
        }
    }
    
    public void Expand()
    {
        
    }

    public TreeNode Select()
    {
        TreeNode selected = null;
        double bestValue = Double.MinValue;
        foreach (TreeNode c in children)
        {
            //UCT value calculation
            double uctValue =
                c.totValue / (c.nVisits + epsilon) +
                Math.Sqrt(Math.Log(nVisits + 1) / (c.nVisits + epsilon)) +
                r.NextDouble() * epsilon; // small random number to break ties randomly in unexpanded nodes
            c.uctValue = uctValue;
            if (uctValue > bestValue)
            {
                selected = c;
                bestValue = uctValue;
            }
        }
        return selected;
    }

    public bool IsLeaf()
    {
        return children.Count == 0;
    }

    public void UpdateStats()
    {
        
    }
}
