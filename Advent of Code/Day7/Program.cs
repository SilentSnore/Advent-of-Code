using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            //string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example.txt");
            string[] lines = hugeText.Split('\n');

            List<Node<string, int>> nodes = new List<Node<string, int>>(lines.Length);
            foreach (string line in lines)
            {
                string[] info = line.Split(' ');
                string name = info[0].Trim();
                string size = info[1].Trim().Trim('(').Trim(')');
                nodes.Add(new Node<string, int>(name, Int32.Parse(size)));
            }

            foreach (string line in lines)
            {
                string[] info = line.Split(' ');
                if(info.Length < 3)
                    continue;
                string parentName = info[0].Trim();
                for (int i = 3; i < info.Length; i++)
                {
                    string childName = info[i].Trim().Trim(',');
                    Node<string, int> child = nodes.Find(node => node.Name.Equals(childName));
                    Node<string, int> parent = nodes.Find(node => node.Name.Equals(parentName));
                    parent.AddChild(child);
                }
            }
            Node<string, int> root = null;
            foreach (Node<string, int> node in nodes)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine(node.Name);
                    root = node;
                    break;
                }
            }

            //drugi
            List<Node<string, int>> unbalancedNodes = new List<Node<string, int>>();
            Find(root, unbalancedNodes);
            //Node<string, int> suspect = nodes.Find(node => node.Name.Equals("kzltfq"));
            Node<string, int> suspect = unbalancedNodes.First(node => !node.Name.Equals(root.Name));
            Console.WriteLine(GetBalancedSize(suspect));
            
            Console.ReadKey();
        }

        private static int CalculateWeight(Node<string, int> node)
        {
            int myWeight = node.Size;
            foreach (Node<string, int> child in node.Children)
            {
                myWeight += CalculateWeight(child);
            }
            return myWeight;
        }

        private static bool CheckNode(Node<string, int> node)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (Node<string, int> child in node.Children)
            {
                set.Add(CalculateWeight(child));
            }
            if (set.ToList().Count > 1)
                return false;
            return true;
        }

        private static int GetBalancedSize(Node<string, int> node)
        {
            List<int> listOfTotalWeights = new List<int>();
            List<int> listOfChildWeights = new List<int>();
            foreach (Node<string, int> child in node.Children)
            {
                listOfTotalWeights.Add(CalculateWeight(child));
                listOfChildWeights.Add(child.Size);
            }

            int min = listOfTotalWeights.Min(),
                max = listOfTotalWeights.Max(),
                numOfMins = listOfTotalWeights.Count(size => size == min),
                numOfMaxs = listOfTotalWeights.Count(size => size == max),
                diff = Math.Abs(max - min);
            if (numOfMins > numOfMaxs)
                return listOfChildWeights[listOfTotalWeights.FindIndex(size => size == max)] - diff;
            return listOfChildWeights[listOfTotalWeights.FindIndex(size => size == min)] + diff;
        }

        private static void Find(Node<string, int> node, List<Node<string, int>> unbalancedNodes)
        {
            foreach (Node<string, int> child in node.Children)
            {
                Find(child, unbalancedNodes);
            }
            if (node.Parent != null)
            {
                if (!CheckNode(node.Parent))
                    unbalancedNodes.Add(node.Parent);
            }
        }

        //private static void print(Node<string, int> node, int depth)
        //{
        //    Console.WriteLine(node.Name);
        //    for(int i = 0; i < depth; i++)
        //        Console.Write(" ");
        //    foreach (Node<string, int> child in node.Children)
        //    {
        //        print(child, depth + 1);
        //    }
        //}
    }

    internal class Node<T, TK>
    {
        public T Name { get; }
        public TK Size { get; set; }
        public List<Node<T, TK>> Children { get; }
        public Node<T, TK> Parent { get; set; }

        public Node(T name, TK size)
        {
            Name = name;
            Size = size;
            Children = new List<Node<T, TK>>();
            Parent = null;
        }

        public Node(T name, TK size, Node<T, TK> parent)
        {
            Name = name;
            Size = size;
            Children = new List<Node<T, TK>>();
            Parent = parent;
            parent.AddChild(this);
        }

        public void AddChild(Node<T, TK> child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public void AddParent(Node<T, TK> parent)
        {
            Parent = parent;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Node<string, int> other))
                return false;
            return Name.Equals(other.Name);
        }
    }
}
