using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir4
{
    public class Node
    {
        public (int, int) State { get; }
        public Node Parent { get; }
        public string Action { get; }

        public Node((int, int) state, Node parent, string action)
        {
            State = state;
            Parent = parent;
            Action = action;
        }
    }

}
