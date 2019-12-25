using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    public class Node<T>
    {
        private T testForm;
        private Node<T> left;
        private Node<T> right;

        public Node(T testForm, Node<T> left, Node<T> right)
        {
            this.testForm = testForm;
            this.left = left;
            this.right = right;
        }

        public Node<T> Left { get => left; set => left = value; }
        public Node<T> Right { get => right; set => right = value; }
        public T TestForm { get => testForm; set => testForm = value; }
    }
}
