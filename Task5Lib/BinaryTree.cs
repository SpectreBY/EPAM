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
    public class BinaryTree<T> where T : TestForm
    {
        /// <summary>
        /// List which store balanced nodes
        /// </summary>
        private List<Node<T>> balancedNodes;

        /// <summary>
        /// List which store test forms
        /// </summary>
        private List<T> testForms;

        /// <summary>
        /// Field which store reference on root node
        /// </summary>
        private Node<T> rootNode;

        /// <summary>
        /// Field which store reference on current node
        /// </summary>
        private Node<T> node;

        /// <summary>
        /// Field which store count of nodes
        /// </summary>
        private int nodesCount;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public BinaryTree()
        {
            testForms = new List<T>();
            nodesCount = 0;
        }

        /// <summary>
        /// Property for accessing nodes of balanced binary tree
        /// </summary>
        public List<Node<T>> BalancedNodes { get => balancedNodes; }

        /// <summary>
        /// Property for accessing main root node of binary tree
        /// </summary>
        public Node<T> Root { get => rootNode; }

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
            testForms.Add(testForm);
            if (nodesCount == 0)
            {
                node = new Node<T>(testForm);
                rootNode = node;
            }
            if(nodesCount > 0)
            {
                while (true)
                {                  
                    if (node.Value > testScore)
                    {           
                        if (node.Left == null)
                        {
                            node.Left = new Node<T>(testForm);
                            break;
                        }
                        if (node.Left != null)
                        {
                            node.Left.Root = node;
                            node = node.Left;
                            continue;
                        }
                    }
                    if (node.Value <= testScore)
                    {
                        if (node.Right == null)
                        {
                            node.Right = new Node<T>(testForm);
                            break;
                        }
                        if (node.Right != null)
                        {
                            node.Right.Root = node;
                            node = node.Right;
                            continue;
                        }
                    }
                }
            }
            node = rootNode;
            nodesCount++;
        }

        /// <summary>
        /// Method for remove node from binary tree
        /// </summary>
        /// <param name="testform"></param>
        public void RemoveFromTree(T testform)
        {
            Node<T> foundedNode = FindNodeByTestFormValue(testform);
            Node<T> node = foundedNode;

            if (node.Left == null && node.Right == null)
            {
                if (node.Root.Left.Equals(node))
                {
                    node.Root.Left = null;
                }
                else if (node.Root.Right.Equals(node))
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
                    var bufRightLeft = node.Right.Left;
                    var bufRightRight = node.Right.Right;
                    node.TestForm = node.Right.TestForm;
                    node.Right = bufRightRight;
                    node.Left = bufRightLeft;
                }
            }
            foundedNode = null;
        }

        /// <summary>
        /// Method for find node by test form value
        /// </summary>
        /// <param name="testForm"></param>
        /// <returns></returns>
        public Node<T> FindNodeByTestFormValue(T testForm)
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
            Node<T> currentNode = rootNode;
            Node<T> resultNode;
            while(true)
            {
                if(currentNode.Value == testScore)
                {
                    resultNode = currentNode;
                    break;
                }
                else if(currentNode.Value > testScore)
                {
                    currentNode = currentNode.Left;
                    if(currentNode == null)
                    {
                        return currentNode;
                    }
                    continue;
                }
                else if (currentNode.Value < testScore)
                {
                    currentNode = currentNode.Right;
                    if (currentNode == null)
                    {
                        return currentNode;
                    }
                    continue;
                }
            }
            return resultNode;
        }

        /// <summary>
        /// Method for balancing a binary tree
        /// </summary>
        public void BalanceTree()
        {
            balancedNodes = new List<Node<T>>();
            Node<T> node = rootNode;
            AddNodesToList(node);
            balancedNodes = balancedNodes.OrderBy(o => o.Value).ToList();

            foreach (var item in balancedNodes)
            {
                item.Left = null;
                item.Right = null;
            }

            BalanceTree(0, balancedNodes.Count - 1);
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
        /// Method for add nodes to collection
        /// </summary>
        /// <param name="node"></param>
        private void AddNodesToList(Node<T> node)
        {  
            if (node != null)
            {
                AddNodesToList(node.Left);
                AddNodesToList(node.Right);
                balancedNodes.Add(node);
            }
        }

        /// <summary>
        /// Method for write nodes of binary tree to xml file
        /// </summary>
        public bool Serialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(MathTestForm), typeof(PhysicsTestForm) });
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
