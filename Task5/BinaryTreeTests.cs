using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5Lib;

namespace Task5
{
    [TestClass]
    public class BinaryTreeTests
    {
        BinaryTree<object> binaryTree = new BinaryTree<object>();

        MathTestForm test1 = new MathTestForm("Student 1", "Math Test", DateTime.Now, 26);
        MathTestForm test2 = new MathTestForm("Student 2", "Math Test", DateTime.Now, 23);
        MathTestForm test3 = new MathTestForm("Student 3", "Math Test", DateTime.Now, 33);
        PhysicsTestForm test4 = new PhysicsTestForm("Student 4", "Physics Test", DateTime.Now, 11);
        PhysicsTestForm test5 = new PhysicsTestForm("Student 5", "Physics Test", DateTime.Now, 36);
        PhysicsTestForm test6 = new PhysicsTestForm("Student 6", "Physics Test", DateTime.Now, 5);
        MathTestForm test7 = new MathTestForm("Student 7", "Math Test", DateTime.Now, 16);
        MathTestForm test8 = new MathTestForm("Student 8", "Math Test", DateTime.Now, 35);
        MathTestForm test9 = new MathTestForm("Student 9", "Math Test", DateTime.Now, 54);

        [TestMethod]
        public void AddToBinaryTreeTest()
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
        }

        [TestMethod]
        public void SerializationAndDeserializationTreeTest()
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
            binaryTree.Serialization();
            binaryTree.Deserialization();
        }
    }
}
