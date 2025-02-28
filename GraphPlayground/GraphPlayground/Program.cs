using System;
using System.Collections.Generic;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace GraphPlayground
{
    internal class Program
    {
        public static void DFS(Graph graph, Node startNode, Node targetNode = null)
        {
            Node currentNode = startNode;
            List<Node> visited = new List<Node>();
            while (visited.Count < graph.nodes.Count) { }
            /*while (startNode.neighbors.Find(node => !node.visited) != default(Node)) ;*/
            
            /*bool shouldContinue = true;
            while (shouldContinue)
            {


                shouldContinue = false;
                foreach (Node neighbor in startNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        shouldContinue = true;
                        break;
                    }
                }
            }*/
        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null)
        {
            Console.WriteLine("Starting node:" + startNode.index);
            Node currentNode = null ;
            List<Node> queue = new List<Node>() { startNode } ;    
            startNode.visited = true ;
            while (queue.Count > 0)
            {
                currentNode = queue[0];                
                Console.WriteLine("Current node:" + currentNode.index);
                queue.RemoveAt(0);
                foreach (Node neighbor in currentNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        queue.Add(neighbor);
                        neighbor.visited = true;
                        Console.WriteLine(" Adding node: " + neighbor.index + " to queue");
                    }
                    else Console.WriteLine(" Node: " + neighbor.index + " already visited or is in queue");
                }                
            }
            Console.WriteLine(" Final node: " + currentNode.index);           
        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();
            DFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);
            BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}
