using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class CitireInorder
    {
        private TreeNode<int> root;

        private int[] numere;
        private int n;

        private int i = -1;
        public CitireInorder()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\CitInorder.in.txt");

            String linie = reader.ReadLine();

            numere = new int[linie.Split(' ').Length];

            n = linie.Split(' ').Length;

            for (int i = 0; i < n; i++)
            {
                numere[i] = int.Parse(linie.Split(' ')[i]);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(numere[i] + " ");
            }

            Console.WriteLine();

            root = built();

            inorder(root);
        }

        public TreeNode<int> built()
        {
            i++;

            if (numere[i] == 0) 
            {
                return null;
            }

            TreeNode<int> nou = new TreeNode<int>();

            nou.Data = numere[i];

            nou.Left = built();
            nou.Right = built();

            return nou;
        }

        public void inorder(TreeNode<int> node)
        {
            if (node == null)
                return;

            inorder(node.Left);

            Console.WriteLine(node.Data);

            inorder(node.Right);
        }
    }
}
