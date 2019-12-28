using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task5Lib
{
    public class BinaryTree<T>
    {
        private List<Node<T>> nodes;
        private List<T> testForms;

        public BinaryTree()
        {
            nodes = new List<Node<T>>();
            testForms = new List<T>();
        }

        public void AddToTree(T testForm)
        {
            Node<T> node;
            testForms.Add(testForm);
            if (nodes.Count == 0)
            {
                node = new Node<T>(testForm);
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

                    if (root.Value >= testScore)
                    {
                        if(root.Left == null)
                        {
                            root.Left = new Node<T>(testForm);
                            nodes.Add(root.Left);
                            break;
                        }
                        if(root.Left != null)
                        {
                            root = root.Left;
                            continue;
                        }
                    }
                    if (root.Value < testScore)
                    {
                        if (root.Right == null)
                        {
                            root.Right = new Node<T>(testForm);
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

        public void Serialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(MathTestForm), typeof(PhysicsTestForm)});
            using (FileStream fs = new FileStream("tests.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, testForms);
            }
        }

        public void Deserialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(MathTestForm), typeof(PhysicsTestForm) });
            using (FileStream fs = new FileStream("tests.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                testForms.Clear();
                testForms = (List<T>)formatter.Deserialize(fs);
            }
        }
    }
}
