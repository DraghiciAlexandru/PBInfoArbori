using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class PB760
    {
        private TreeNode<int> root;
        private int k;

        private int[] numere;
        private int n;

        private int i = -1;
        public PB760()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\knivel1.in.txt");

            String linie = reader.ReadLine();

            numere = new int[linie.Split(' ').Length];
            n = linie.Split(' ').Length;

            for (int i = 0; i < n; i++)
            {
                numere[i] = int.Parse(linie.Split(' ')[i]);
            }

            k = int.Parse(reader.ReadLine());

            root = read();

            Console.WriteLine(sumaK(root));
        }

        public TreeNode<int> read()
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

        public int sumaK(TreeNode<int> node)
        {
            if (node == null)
                return 0;

            if (nivel(root, node.Data) == k)
                return node.Data + sumaK(node.Left) + sumaK(node.Right);

            return sumaK(node.Left) + sumaK(node.Right);
        }

        public TreeNode<int> find(TreeNode<int> node, int data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.Equals(data))
            {
                return node;
            }

            TreeNode<int> left = find(node.Left, data);

            if (left != null)
            {
                return left;
            }


            return find(node.Right, data);
        }

        public int nivel(TreeNode<int> node, int data)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.Data.Equals(data))
            {
                return nivel(null, data);
            }

            else if (find(node.Left, data) != null)
                return 1 + nivel(node.Left, data);
            else if (find(node.Right, data) != null)
                return 1 + nivel(node.Right, data);

            return -1;
        }

    }
}
