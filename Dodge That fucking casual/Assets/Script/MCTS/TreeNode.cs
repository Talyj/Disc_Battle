using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeNode : MonoBehaviour
{

    [SerializeField] private PlayerController p2;
    [SerializeField] private PlayerController p1;
    private Vector3 positionP1;
    private Vector3 positionP2;

    static System.Random r = new System.Random();
    public static double epsilon = 1e-6;
    
    public List<TreeNode> children;
    public double nVisits, totValue;
    public double uctValue;

    private int randomActionTime;
    
    public State state;


    public void Start()
    {
        positionP1 = p1.transform.position;
        positionP2 = p2.transform.position;
    }

    public void Update()
    {
        //DoRandomMoveP1();
        Debug.Log(positionP1);
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

    public double Simulate()
    {
        return 0.0;
    }
    
    public void UpdateStats()
    {
        
    }

    public void DoRandomMoveP1()
    {
        var actionIdP1 = Random.Range(0, 5);
        if (actionIdP1 != 4)
        {
            randomActionTime = Random.Range(10, 30);   
        }
        switch (actionIdP1)
        {
            case 0:
                positionP1 += p1.WalkToUpPlayer1(randomActionTime);
                break;
            case 1:
                positionP1 += p1.WalkToDownPlayer1(randomActionTime);
                break;
            case 2:
                positionP1 += p1.WalkToLeftPlayer1(randomActionTime);
                break;
            case 3:
                positionP1 += p1.WalkToRightPlayer1(randomActionTime);
                break;
            case 4:
                p2.Smash();
                break;
        }
    }
    
    //Type to change
    public void DoRandomMoveP2()
    {
        var actionIdP2 = Random.Range(0, 5);
        
        if (actionIdP2 != 4)
        {
            randomActionTime = Random.Range(10, 30);   
        }
        switch (actionIdP2)
        {
            case 0:
                positionP2 += p2.WalkToUpPlayer2(randomActionTime);
                break;
            case 1:
                positionP2 += p2.WalkToDownPlayer2(randomActionTime);
                break;
            case 2:
                positionP2 += p2.WalkToLeftPlayer2(randomActionTime);
                break;
            case 3:
                positionP2 += p2.WalkToRightPlayer2(randomActionTime);
                break;
            case 4:
                p2.Smash();
                break;
        }
    }

    //Parameters to add
    public int CheckWin()
    {
        return 0;
    } 
}
