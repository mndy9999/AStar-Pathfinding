using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarSearch : MonoBehaviour {

    List<Node> openSet;
    List<Node> closedSet;

    public Transform startPos;
    public Transform endPos;

    Grid grid;
    Node startNode;
    Node endNode;
    Node currentNode;

    private void Start()
    {
        grid = GetComponent<Grid>();        
    }

    public void Update()
    {
        search(startPos.position, endPos.position);
    }

    void search(Vector2 startPos, Vector2 endPos)
    {
        openSet = new List<Node>();
        closedSet = new List<Node>();

        startNode = grid.getNodeFromWorldPoint(startPos);
        endNode = grid.getNodeFromWorldPoint(endPos);

        openSet.Add(startNode);
        
        while(openSet.Count > 0)
        {
            currentNode = openSet[0];
            for(int i=0; i < openSet.Count;i++)
            {
                if(openSet[i].getFCost() < currentNode.getFCost() || (openSet[i].getFCost() == currentNode.getFCost() && openSet[i].hCost < currentNode.hCost))
                {
                    
                    currentNode = openSet[i];   
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == endNode) { getPath(startNode, endNode); break; }

            foreach(Node node in grid.getNeighbours(currentNode))
            {
                if (!node.walkable || closedSet.Contains(node)) { continue; }
                int moveCost = currentNode.gCost * getDistance(currentNode, node);
                if(moveCost<node.gCost || !openSet.Contains(node))
                {
                    node.gCost = moveCost;
                    node.hCost = getDistance(node, endNode);
                    node.parent = currentNode;
                    if (!openSet.Contains(node)) { openSet.Add(node); }
                }
            }

        }
    }

    void getPath(Node _startNode, Node _endNode)
    {
        List<Node> path = new List<Node>();
        Node node = endNode;
        while(node != startNode)
        {
            path.Add(node);
            node = node.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int getDistance(Node a, Node b)
    {
        int x = Mathf.Abs(a.gridX - b.gridX);
        int y = Mathf.Abs(a.gridY - b.gridY);
        
        if(x > y) { return 14 * y + 10 * (x - y); }
        else { return 14 * x + 10 * (y - x); }
    }
}
