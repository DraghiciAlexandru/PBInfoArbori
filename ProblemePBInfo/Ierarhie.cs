using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemePBInfo
{
    class Ierarhie<T> where T : IComparable<T>
    {
        TreeNode<T> root;

        public TreeNode<T> Root
        {
            get { return root; }
        }

        public Ierarhie(T data)
        {

            root = new TreeNode<T> { Data = data, Left = null, Right = null };

        }

        public TreeNode<T> find(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.Equals(data))
            {
                return node;
            }

            TreeNode<T> left= find(node.Left, data);

            if (left != null)
            {
                return left;
            }


            return find(node.Right, data);
        }

        public bool addSubordinate(T manager, T subordonat)
        {
            TreeNode<T> node = find(root, manager);

            if (node == null)
            {
                return false;
            }

            if (node.Left != null && node.Right != null)
            {
                return false;
            }

            if (node.Left == null)
            {
                node.Left = new TreeNode<T> { Data = subordonat, Left = null, Right = null };
                return true;
            }
            else
            {
                node.Right = new TreeNode<T> { Data = subordonat, Left = null, Right = null };
                return true;
            }
        }

        public void afisare()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null) 
                {
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null) 
                {
                    queue.Enqueue(queue.Peek().Right);
                }

                Console.Write(queue.Peek().Data + " ");

                queue.Dequeue();
            }
        }

        public void preorder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);

            preorder(node.Left);
            preorder(node.Right);
        }

        public void inorder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            inorder(node.Left);

            Console.Write(node.Data + " ");

            inorder(node.Right);
        }

        public void postorder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            postorder(node.Left);
            postorder(node.Right);
            Console.WriteLine(node.Data);
        }
    }
}
