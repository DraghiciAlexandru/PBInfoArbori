using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemePBInfo
{
    class PB675
    {
        int n;
        int[,] matrice;

        public PB675()
        {
            open();
            write();
        }

        public void open()
        {
            StreamReader reader = new StreamReader(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\bifrunze.in.txt");
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

        public void write()
        {
            StreamWriter write = new StreamWriter(@"D:\C#\ConsoleApps\OOP\StructuriDeDateGenerice\ProblemePBInfo\ProblemePBInfo\bifrunze.out.txt");

            for (int i = 0; i < n; i++)
            {
                if (matrice[i, 1] == 0 && matrice[i, 2] == 0) 
                    write.Write((i + 1) + " ");
            }

            write.Close();
        }

    }
}
