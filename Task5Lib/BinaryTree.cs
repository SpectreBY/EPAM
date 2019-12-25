using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    public class BinaryTree<T>
    {
        private List<T> nodes;
        public BinaryTree()
        {
            nodes = new List<T>();
        }

        public void AddToTree(T node)
        {
            nodes.Add(node);
        }
    }
}
