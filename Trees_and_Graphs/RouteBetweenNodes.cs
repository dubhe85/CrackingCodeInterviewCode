using System;
using System.Collections.Generic;

// Exercise 4.1
namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{

    enum State
    { 
        Unvisited, 
        Visited, 
        Visiting
    }

    class Graph
    {
        public Node[] nodes;

        public Node[] GetNodes()
        {
            // this should return all nodes in the graph not only nodes list.
            // It should return nodes of nodes of nodes etc.
            return nodes;
        }
    }

    
    class Node
    {
        public string Name;
        public Node[] Children;
        public State State;

        public Node[] GetAdjacent()
        {
            // return adjacent nodes
            return null;
        }
    }
    

    class RouteBetweenNodes
    {

        // Iterative implementation of bread-first search.
        public bool search(Graph graph, Node start, Node end)
        {

            if (start == end)
            {
                return true;
            }

            // operates as queue
            LinkedList<Node> q = new LinkedList<Node>();

            foreach (var u in graph.GetNodes())
            {
                u.State = State.Unvisited;
            }

            start.State = State.Visiting;
            q.AddLast(start);
            Node tempNode = null;

            while (q.Count > 0)
            {
                tempNode = q.First.Value; //
                q.RemoveFirst(); // i.e., dequeue()
                if (tempNode != null)
                {
                    foreach (Node v in tempNode.GetAdjacent())
                    {
                        if (v.State == State.Unvisited)
                        {
                            if (v == end)
                            {
                                return true;
                            }
                            else
                            {
                                v.State = State.Visiting;
                                q.AddLast(v);
                            }
                        }
                    }

                    tempNode.State = State.Visited;
                }
            }

            return false;
        }
    }
}
