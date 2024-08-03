using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir4
{
    public class QueueFrontier : StackFrontier
    {
        public new Node Remove()
        {
            if (Empty())
            {
                throw new Exception("empty frontier");
            }
            else
            {
                Node node = frontier.First();
                frontier.RemoveAt(0);
                return node;
            }
        }
    }
}
