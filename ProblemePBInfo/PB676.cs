using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class PB676
    {
        int n;
        int[,] matrice;

        int k;
        int[] noduri;

        Ierarhie<int> ierarhie;

        public PB676()
        {
            open();

            findRoot();

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(countPrim(ierarhie.find(ierarhie.Root, matrice[noduri[i] - 1, 0])));
            }
        }

        public void open()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\countsub.in.txt");
            String linie = "";

            n = int.Parse(reader.ReadLine());

            matrice = new int[n, 3];

            int ct = 0;

            while ((linie = reader.ReadLine()).Split(' ').Length == 3)
            {
                matrice[ct, 0] = int.Parse(linie.Split(' ')[0]);
                matrice[ct, 1] = int.Parse(linie.Split(' ')[1]);
                matrice[ct, 2] = int.Parse(linie.Split(' ')[2]);

                ct++;
            }

            k = int.Parse(linie);

            noduri = new int[k];

            for (int i = 0; i < k; i++)
            {
                noduri[i] = int.Parse(reader.ReadLine());
            }

            reader.Close();
        }

        public void findRoot()
        {
            int[] numere = new int[n + 1];
            for (int i = 0; i <= n; i++)
                numere[i] = i;

            for (int i = 0; i < n; i++)
            {
                numere[matrice[i, 1]] = 0;
                numere[matrice[i, 2]] = 0;
            }

            for (int i = 0; i <= n; i++)
                if (numere[i] != 0)
                {
                    ierarhie = new Ierarhie<int>(matrice[numere[i] - 1, 0]);

                    built(matrice[numere[i] - 1, 0], matrice[numere[i] - 1, 1], matrice[numere[i] - 1, 2]);
                }
        }

        public void built(int manager, int subordonat1, int subordonat2)
        {
            if (subordonat1 != 0)
            {
                ierarhie.addSubordinate(manager, matrice[subordonat1 - 1, 0]);

                built(matrice[subordonat1 - 1, 0], matrice[subordonat1 - 1, 1], matrice[subordonat1 - 1, 2]);
            }

            if (subordonat2 != 0)
            {
                ierarhie.addSubordinate(manager, matrice[subordonat2 - 1, 0]);

                built(matrice[subordonat2 - 1, 0], matrice[subordonat2 - 1, 1], matrice[subordonat2 - 1, 2]);
            }
        }

        public bool prim(int nr)
        {
            if (nr == 0 || nr == 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(nr); i++)
                if (nr % i == 0)
                    return false;

            return true;
        }

        public int countPrim(TreeNode<int> node)
        {
            if (node == null)
                return 0;

            if (prim(node.Data))
                return 1 + countPrim(node.Left) + countPrim(node.Right);
            else
                return countPrim(node.Left) + countPrim(node.Right);
        }

    }
}
