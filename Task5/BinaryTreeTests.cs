using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5Lib;

namespace Task5
{
    /// <summary>
    /// Thats class represents tests for binary trees
    /// </summary>
    [TestClass]
    public class BinaryTreeTests
    {
        private BinaryTree<object> binaryTree = new BinaryTree<object>();
        private List<int> nodeValues = new List<int>();
        private List<int> orderedNodeValues = new List<int>();

        private MathTestForm test1 = new MathTestForm("Student 1", "Math Test", DateTime.Now, 26);
        private MathTestForm test2 = new MathTestForm("Student 2", "Math Test", DateTime.Now, 23);
        private MathTestForm test3 = new MathTestForm("Student 3", "Math Test", DateTime.Now, 33);
        private PhysicsTestForm test4 = new PhysicsTestForm("Student 4", "Physics Test", DateTime.Now, 11);
        private PhysicsTestForm test5 = new PhysicsTestForm("Student 5", "Physics Test", DateTime.Now, 36);
        private PhysicsTestForm test6 = new PhysicsTestForm("Student 6", "Physics Test", DateTime.Now, 5);
        private MathTestForm test7 = new MathTestForm("Student 7", "Math Test", DateTime.Now, 16);
        private MathTestForm test8 = new MathTestForm("Student 8", "Math Test", DateTime.Now, 35);
        private MathTestForm test9 = new MathTestForm("Student 9", "Math Test", DateTime.Now, 54);

        /// <summary>
        /// Test for fill binary tree
        /// </summary>
        [TestMethod]
        public void AddToBinaryTreeTest()
        {
            AddNodes();
            Assert.IsTrue(BinaryTreeEquals());
        }

        /// <summary>
        /// Test for remove node from binary tree
        /// </summary>
        [TestMethod]
        public void RemoveFromBinaryTreeTest()
        {
            AddNodes();
            binaryTree.RemoveFromTree(3);
            bool removed = true;
            foreach(var node in binaryTree.Nodes)
            {
                if(node.TestForm.Equals(test4))
                {
                    removed = false;
                    break;
                }
            }
            Assert.IsTrue(removed);
        }

        /// <summary>
        /// Test for balancing binary tree
        /// </summary>
        [TestMethod]
        public void BalanceBinaryTreeTest()
        {
            AddNodes();
            binaryTree.BalanceTree();
            Assert.IsTrue(BalancedBinaryTreeEquals());
        }

        /// <summary>
        /// Test for serialization binary tree to xml file
        /// </summary>
        [TestMethod]
        public void SerializationTreeTest()
        {
            AddNodes();
            Assert.IsTrue(binaryTree.Serialization());
        }

        /// <summary>
        /// Test for deserialization xml file
        /// </summary>
        [TestMethod]
        public void DeserializationTreeTest()
        {
            AddNodes();
            binaryTree.Serialization();
            Assert.IsTrue(binaryTree.Deserialization());
        }

        /// <summary>
        /// Helper method for fill binary tree
        /// </summary>
        private void AddNodes()
        {
            binaryTree.AddToTree(test1);
            binaryTree.AddToTree(test2);
            binaryTree.AddToTree(test3);
            binaryTree.AddToTree(test4);
            binaryTree.AddToTree(test5);
            binaryTree.AddToTree(test6);
            binaryTree.AddToTree(test7);
            binaryTree.AddToTree(test8);
            binaryTree.AddToTree(test9);
            nodeValues.Add(test1.TestScore);
            nodeValues.Add(test2.TestScore);
            nodeValues.Add(test3.TestScore);
            nodeValues.Add(test4.TestScore);
            nodeValues.Add(test5.TestScore);
            nodeValues.Add(test6.TestScore);
            nodeValues.Add(test7.TestScore);
            nodeValues.Add(test8.TestScore);
            nodeValues.Add(test9.TestScore);
            orderedNodeValues = nodeValues.OrderBy(o => o).ToList();
        }

        /// <summary>
        /// Helper method for comparison binary trees
        /// </summary>
        /// <returns></returns>
        private bool BinaryTreeEquals()
        {
            Node<object> root = binaryTree.GetNodesRoot;
            if (root.Value != nodeValues[0])
                return false;
            else if (root.Left.Value != nodeValues[1])
                return false;
            else if (root.Right.Value != nodeValues[2])
                return false;
            else if (root.Left.Left.Value != nodeValues[3])
                return false;
            else if (root.Right.Right.Value != nodeValues[4])
                return false;
            else if (root.Left.Left.Left.Value != nodeValues[5])
                return false;
            else if (root.Left.Left.Right.Value != nodeValues[6])
                return false;
            else if (root.Right.Right.Left.Value != nodeValues[7])
                return false;
            else if (root.Right.Right.Right.Value != nodeValues[8])
                return false;
            return true;
        }

        /// <summary>
        /// Helper method for comparison balanced binary trees
        /// </summary>
        /// <returns></returns>
        private bool BalancedBinaryTreeEquals()
        {
            Node<object> root = binaryTree.GetBalancedNodesRoot;
            if (root.Value != orderedNodeValues[4])
                return false;
            else if (root.Left.Value != orderedNodeValues[1])
                return false;
            else if (root.Left.Left.Value != orderedNodeValues[0])
                return false;
            else if (root.Left.Right.Value != orderedNodeValues[2])
                return false;
            else if (root.Left.Right.Right.Value != orderedNodeValues[3])
                return false;
            else if (root.Right.Value != orderedNodeValues[6])
                return false;
            else if (root.Right.Left.Value != orderedNodeValues[5])
                return false;
            else if (root.Right.Right.Value != orderedNodeValues[7])
                return false;
            else if (root.Right.Right.Right.Value != orderedNodeValues[8])
                return false;
            return true;
        }
    }
}
