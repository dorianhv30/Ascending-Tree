using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

    class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public int Data { get; set; }
    }

    class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftChild;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightChild;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftChild = newNode;
                else
                    before.RightChild = newNode;
            }

            return true;
        }



        public List<int> GetOrderedWeights(Node parent)
        {
            List<int> result = new List<int>();
            result = GetOrderedList(parent, result);
            return result;
        }

        public List<int> GetOrderedList(Node parent, List<int> Ordered)
        {

            if (parent != null)
            {
                GetOrderedList(parent.LeftChild, Ordered);
                Ordered.Add(parent.Data);
                GetOrderedList(parent.RightChild, Ordered);
            }
            return Ordered;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);



            var list = binaryTree.GetOrderedWeights(binaryTree.Root);


            Console.ReadLine();
        }
    }
}
