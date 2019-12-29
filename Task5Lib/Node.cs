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
        private Node<T> root;
        private Node<T> left;
        private Node<T> right;

        public Node(T testForm, Node<T> root)
        {
            this.testForm = testForm;
            left = null;
            right = null;
            this.root = root;
        }

        public Node<T> Root { get => root; set => root = value; }
        public Node<T> Left { get => left; set => left = value; }
        public Node<T> Right { get => right; set => right = value; }
        public T TestForm { get => testForm; set => testForm = value; }

        public int Value
        {
            get
            {
                if(testForm is MathTestForm)
                {
                    MathTestForm form = testForm as MathTestForm;
                    return form.TestScore;
                }
                else if (testForm is PhysicsTestForm)
                {
                    PhysicsTestForm form = testForm as PhysicsTestForm;
                    return form.TestScore;
                }
                return 0;
            }
        }

    }
}
