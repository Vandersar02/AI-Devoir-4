using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir4
{
    public class StackFrontier
    {
        public List<Node> frontier;

        public StackFrontier()
        {
            frontier = new List<Node>();
        }

        public void Add(Node node)
        {
            frontier.Add(node);
        }

        public bool ContainsState((int, int) state)
        {
            return frontier.Any(node => node.State == state);
        }

        public bool Empty()
        {
            return frontier.Count == 0;
        }

        public Node Remove()
        {
            if (Empty())
            {
                throw new Exception("empty frontier");
            }
            else
            {
                Node node = frontier.Last();
                frontier.RemoveAt(frontier.Count - 1);
                return node;
            }
        }
    }

}
