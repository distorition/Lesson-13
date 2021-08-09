using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_13._1
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

    }

    public class BinaryTree
    {
        public Node<int> root;
        public BinaryTree()
        {
            root = null;
        }
         public void RemoveNode(Node<int> num)
        {
         if(root==num)
            {
                root = null;
            }
                
                RemoveNode(root.Left);
                RemoveNode(root.Right);
            Console.WriteLine("", root.Data);
            
            
        }

        public void AddNode(int num)
        {
            Node<int> node = new Node<int>();
            node.Data = num;
            if(root==null)
            {
                root = node;
            }
            else {
                Node<int> current = root;
                Node<int> parent;

                while(true)
                {
                    parent = current;
                    if(num<current.Data)
                    {
                        current = current.Left;
                        if(current==null)
                        {
                            parent.Left = node;
                            break;
                        }
                        else
                        {
                            current = current.Right;
                            if(current==null)
                            {
                                parent.Right = node;
                                break;
                            }
                        }
                    }
                }
            }
        }



    }


    class Program
    {
       
        public static  Node<int> FindNode(Node<int> startNode, int value)
        {
            var curNode = startNode;
            while(curNode!=null)
            {
                if(curNode.Data==value)
                {
                    return curNode;
                }
                curNode = curNode.Left;
                curNode = curNode.Right;
            }
            return null;
        }

     
      
 
     
        public static Node<int> Tree(int n)
        {
            Node<int> newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node<int>();
                newNode.Data = new Random().Next();
                newNode.Left = Tree(nl);
                newNode.Right = Tree(nr);
            }
            return newNode;
        }
        public void GetTree(Node<int> root)
        {
            if (root != null)
            {
                Console.WriteLine("", root.Data);
                GetTree(root.Left);
                GetTree(root.Right);
            }
        }








        static void Main(string[] args)
        {
            
        }

    }
}
