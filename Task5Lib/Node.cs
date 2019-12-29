using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    /// <summary>
    /// Thats class represents node of binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        private T testForm;
        private Node<T> root;
        private Node<T> left;
        private Node<T> right;

        /// <summary>
        /// Contructor with few parameters
        /// </summary>
        /// <param name="testForm"></param>
        /// <param name="root"></param>
        public Node(T testForm, Node<T> root)
        {
            this.testForm = testForm;
            left = null;
            right = null;
            this.root = root;
        }

        /// <summary>
        /// Property for storing linked parent node
        /// </summary>
        public Node<T> Root { get => root; set => root = value; }

        /// <summary>
        /// Property for storing linked left node
        /// </summary>
        public Node<T> Left { get => left; set => left = value; }

        /// <summary>
        /// Property for storing linked right node
        /// </summary>
        public Node<T> Right { get => right; set => right = value; }

        /// <summary>
        /// Property for storing object of tests (physics or math)
        /// </summary>
        public T TestForm { get => testForm; set => testForm = value; }

        /// <summary>
        /// Property for storing test scores from test form object
        /// </summary>
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
