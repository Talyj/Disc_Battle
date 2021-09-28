using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{

    public List<TreeNode> children;
    public double nVisit, totValue;
    public double utcValue;

    public State state;

    public TreeNode(State state)
    {
        children = new List<TreeNode>();
        nVisit = 0;
        totValue = 0;

        this.state = state;
    }

    public void IterateMTCS()
    {
        
    }
    
    public void Expand()
    {
        
    }

    public TreeNode Select()
    {
        return new TreeNode(state);
    }

    public bool IsLeaf()
    {
        return false;
    }

    public double Simulate()
    {
        return 0.0;
    }
    
    public void UpdateStats()
    {
        
    }

    //Type to change
    public void listPossibleMoves()
    {
        
    }

    //Type to change
    public void DoRandomMove()
    {
        
    }

    //Parameters to add
    public int CheckWin()
    {
        return 0;
    } 
}
