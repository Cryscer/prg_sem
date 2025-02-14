using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    internal class Node
    {
        public int index;
        public List<Node> neighbours;

        public Node(int index)
        {
            this.index = index;
            neighbours = new List<Node>();
        }

        public void AddNeighbour(Node neighbour)
        {
            if (neighbours.Contains(neighbour)) Console.WriteLine("already present");
            else neighbours.Add(neighbour);
        }
        public void AddNeighbours(List<Node> newNeighbours)
        {
            foreach (Node neighbour in newNeighbours) if (neighbours.Contains(neighbour)) Console.WriteLine("already present");
                else neighbours.Add(neighbour);
            //neighbours.AddRange(newNeighbours);
        }

        public void PrintNeighbours()
        {
            Console.Write("Neighbours of node " + index + ": ");
            foreach (Node neighbour in neighbours)
            {
                Console.Write(neighbour.index + " ");
            }
            Console.WriteLine();
        }

        public Node FindNeighbour(int index)
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.index == index) return neighbour;                
            }
            Console.WriteLine("Invalid neighbour");
            return this;
        }
    }
}
