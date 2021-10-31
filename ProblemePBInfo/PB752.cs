using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class PB752
    {
        private TreeNode<int> root;

        private int[] numere;
        private int n;

        private int i = -1;
        public PB752()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\biarbore.in.txt");

            String linie = reader.ReadLine();

            numere = new int[linie.Split(' ').Length];
            n = linie.Split(' ').Length;

            for (int i = 0; i < n; i++) 
            {
                numere[i] = int.Parse(linie.Split(' ')[i]);
            }

            for(int i=0; i<n; i++)
            {
                Console.Write(numere[i] + " ");
            }

            Console.WriteLine();

            root = read();

            preorder(root);

        }
        
        public TreeNode<int > read()
        {
            i++;

            if (numere[i] == 0)
            {
                return null;
            }
          
            TreeNode<int> nou = new TreeNode<int>();

            nou.Data = numere[i];
            nou.Left = read();
            nou.Right = read();

            return nou;
        }

        public void afisare(TreeNode<int> node)
        {
            Queue<TreeNode<int>> treeNodes = new Queue<TreeNode<int>>();

            treeNodes.Enqueue(node);

            while (treeNodes.Count != 0) 
            {
                if (treeNodes.Peek().Left != null)
                {
                    treeNodes.Enqueue(treeNodes.Peek().Left);
                }
                if (treeNodes.Peek().Right != null)
                {
                    treeNodes.Enqueue(treeNodes.Peek().Right);
                }

                Console.WriteLine(treeNodes.Dequeue().Data);
            }
        }

        public void preorder(TreeNode<int> node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Data);

            preorder(node.Left);
            preorder(node.Right);
        }
    }
}
