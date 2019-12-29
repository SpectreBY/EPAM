using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task5Lib
{
    /// <summary>
    /// Thats class represents binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>
    {
        private List<Node<T>> nodes;
        private List<Node<T>> balancedNodes;
        private List<T> testForms;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public BinaryTree()
        {
            nodes = new List<Node<T>>();
            testForms = new List<T>();
        }

        /// <summary>
        /// Property for accessing nodes of binary tree
        /// </summary>
        public List<Node<T>> Nodes { get => nodes; }

        /// <summary>
        /// Property for accessing nodes of balanced binary tree
        /// </summary>
        public List<Node<T>> BalancedNodes { get => balancedNodes; }

        /// <summary>
        /// Property for accessing main root node of binary tree
        /// </summary>
        public Node<T> GetNodesRoot { get => nodes.First();}

        /// <summary>
        /// Property for accessing main root node of balanced binary tree
        /// </summary>
        public Node<T> GetBalancedNodesRoot { get => balancedNodes[balancedNodes.Count / 2]; }

        /// <summary>
        /// Method for add node to binary tree
        /// </summary>
        /// <param name="testForm"></param>
        public void AddToTree(T testForm)
        {
            Node<T> node;
            testForms.Add(testForm);
            if (nodes.Count == 0)
            {
                node = new Node<T>(testForm, null);
                nodes.Add(node);
            }
            else
            {
                Node<T> root = nodes.First();
                while(true)
                {
                    int testScore = 0;
                    if (testForm is MathTestForm)
                    {
                        MathTestForm form = testForm as MathTestForm;
                        testScore = form.TestScore;
                    }
                    else if (testForm is PhysicsTestForm)
                    {
                        PhysicsTestForm form = testForm as PhysicsTestForm;
                        testScore = form.TestScore;
                    }

                    if (root.Value > testScore)
                    {
                        if(root.Left == null)
                        {
                            root.Left = new Node<T>(testForm, root);
                            nodes.Add(root.Left);
                            break;
                        }
                        if(root.Left != null)
                        {
                            root = root.Left;
                            continue;
                        }
                    }
                    if (root.Value <= testScore)
                    {
                        if (root.Right == null)
                        {
                            root.Right = new Node<T>(testForm, root);
                            nodes.Add(root.Right);
                            break;
                        }
                        if (root.Right != null)
                        {
                            root = root.Right;
                            continue;
                        }
                    }
                }          
            }
        }

        /// <summary>
        /// Method for remove node from binary tree
        /// </summary>
        /// <param name="index"></param>
        public void RemoveFromTree(int index)
        {
            if (index > nodes.Count - 1 || index < 0)
                throw new IndexOutOfRangeException();
            Node<T> node = nodes[index];

            if (node.Left == null && node.Right == null)
            {
                if (node.Root.Left.Equals(node))
                {
                    node.Root.Left = null;
                }
                else if(node.Root.Right.Equals(node))
                {
                    node.Root.Right = null;
                }
            }
            else if (node.Left == null)
            {
                if (node.Root.Left.Equals(node))
                {
                    node.Root.Left = node.Right;
                }
                else if (node.Root.Right.Equals(node))
                {
                    node.Root.Right = node.Right;
                }

                node.Right.Root = node.Root;
            }
            else if (node.Right == null)
            {
                if (node.Root.Left.Equals(node))
                {
                    node.Root.Left = node.Left;
                }
                else
                {
                    node.Root.Right = node.Left;
                }

                node.Left.Root = node.Root;
            }
            else
            {
                if (node.Root.Left.Equals(node))
                {
                    node.Root.Left = node.Right;
                    node.Root.Left.Left = node.Left;
                    node.Right.Root = node.Root;
                }
                else if (node.Root.Right.Equals(node))
                {
                    node.Root.Right = node.Right;
                    node.Right.Root = node.Root;
                }
                else
                {
                    var bufLeft = node.Left;
                    var bufRightLeft = node.Right.Left;
                    var bufRightRight = node.Right.Right;
                    node.TestForm = node.Right.TestForm;
                    node.Right = bufRightRight;
                    node.Left = bufRightLeft;
                }
            }
            nodes.RemoveAt(index);
        }

        /// <summary>
        /// Method for balancing a binary tree
        /// </summary>
        public void BalanceTree()
        {
            balancedNodes = nodes.OrderBy(o => o.Value).ToList();

            foreach (var node in balancedNodes)
            {
                node.Left = null;
                node.Right = null;
            }

            BalanceTree(0, nodes.Count - 1);
        }

        /// <summary>
        /// Method for performing binary tree balancing calculations
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Node<T> BalanceTree(int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            balancedNodes[mid].Left = BalanceTree(start, mid - 1);
            balancedNodes[mid].Right = BalanceTree(mid + 1, end);
            return balancedNodes[mid];
        }

        /// <summary>
        /// Method for write nodes of binary tree to xml file
        /// </summary>
        public bool Serialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(MathTestForm), typeof(PhysicsTestForm)});
            using (FileStream fs = new FileStream("tests.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, testForms);
                return true;
            }
        }

        /// <summary>
        /// Method for read nodes of binary tree from xml file
        /// </summary>
        public bool Deserialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(MathTestForm), typeof(PhysicsTestForm) });
            using (FileStream fs = new FileStream("tests.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                testForms.Clear();
                testForms = (List<T>)formatter.Deserialize(fs);
                return true;
            }
        }
    }
}
