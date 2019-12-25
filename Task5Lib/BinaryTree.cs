using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    public class BinaryTree<T>
    {
        private List<Node<T>> nodes;
        public BinaryTree()
        {
            nodes = new List<Node<T>>();
        }

        public void AddToTree(T testForm)
        {
            Node<T> node;
            if (nodes.Count == 0)
            {
                node = new Node<T>(testForm, null, null);
            }
            else
            {
                foreach(var item in nodes)
                {
                    TestForm test = item.TestForm;


                }
            }
        }
    }
}
