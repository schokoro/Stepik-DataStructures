using System;
using System.Collections.Generic;

namespace HeightTree
{
    class Node
    {
        public List<int> children;
        public Node(int child)
        {
            children = new List<int>() { child };
        }

        internal int GetHeight(Node[] node)
        {
            int s = 0;
            foreach (var nods in children)
                if (node[nods] != null)
                    s = Math.Max(s, node[nods].GetHeight(node));
                else s = 1; 
            return s + 1;
        }
    }
}
