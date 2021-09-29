using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeNode : MonoBehaviour
{

    [SerializeField] private PlayerController p2;
    
    static System.Random r = new System.Random();
    public static double epsilon = 1e-6;
    
    public List<TreeNode> children;
    public double nVisits, totValue;
    public double uctValue;

    public State state;

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

    //Type to change
    public void DoRandomMove(int actionId)
    {
        var randomActionTime = Random.Range(10, 30);
        //randomAction = 0;
        switch (actionId)
        {
            case 0:
                p2.WalkToUpPlayer2(randomActionTime);
                break;
            case 1:
                p2.WalkToDownPlayer2(randomActionTime);
                break;
            case 2:
                p2.WalkToLeftPlayer2(randomActionTime);
                break;
            case 3:
                p2.WalkToRightPlayer2(randomActionTime);
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
