using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class PB677
    {
        int n;
        int[,] matrice;

        int[] nivel;

        Ierarhie<int> ierarhie;

        public PB677()
        {
            open();

            findRoot();

            nivel = new int[n + 1];

            for (int i = 0; i <= n; i++)
                nivel[i] = 0;

            nivele(ierarhie.Root);

            afisare(nivel);
        }

        public void open()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\preordine.in.txt");
            String linie = "";

            n = int.Parse(reader.ReadLine());

            matrice = new int[n, 3];

            int ct = 0;

            while ((linie = reader.ReadLine()) != null)
            {
                matrice[ct, 0] = int.Parse(linie.Split(' ')[0]);
                matrice[ct, 1] = int.Parse(linie.Split(' ')[1]);
                matrice[ct, 2] = int.Parse(linie.Split(' ')[2]);

                ct++;
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

        public void nivele(TreeNode<int> node, int level = 0)
        {
            if (node == null)
                return;

            nivel[level]++;

            nivele(node.Left, level + 1);
            nivele(node.Right, level + 1);
        }

        public void afisare(int[] nivel)
        {
            int nrNivele = 0;
            for (int i = 0; i <= n; i++)
            {
                if (nivel[i] != 0)
                    nrNivele++;
            }

            Console.WriteLine(nrNivele);

            for (int i = 0; i <= n; i++) 
            {
                if (nivel[i] != 0)
                    Console.Write(nivel[i] + " ");
            }

        }
    }
}
