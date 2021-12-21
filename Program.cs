using System;
using System.Text;
using System.Collections.Generic;


class Player
{
    static void Calcul_PT(List<string> table, int x1, int y1, out int x2, out int y2, out int x3, out int y3)
    {
        x2 = x1;
        y2 = y1;
        x3 = x1;
        y3 = y1;
        bool rien_a_droite = true;
        bool rien_en_bas = true;

        //a droite
        if (x1 != table[y1].Length - 1)
        {
            for (int i = x1 + 1; i < table[y1].Length; i++)
            {
                if (table[y1][i] == '0' && rien_a_droite)
                {
                    x2 = i;
                    y2 = y1;
                    rien_a_droite = false;
                }
            }
        }
        if (rien_a_droite)
        {
            x2 = -1;
            y2 = -1;
        }
        //en bas
        if (y1 != table.Count - 1)
        {
            for (int i = y1 + 1; i < table.Count; i++)
            {
                if (table[i][x1] == '0' && rien_en_bas)
                {
                    x3 = x1;
                    y3 = i;
                    rien_en_bas = false;
                }
            }
        }
        if (rien_en_bas)
        {
            x3 = -1;
            y3 = -1;
        }
        if (table[y1][x1] == '0')
        {
            Console.WriteLine(x1 + " " + y1 + " " + x2 + " " + y2 + " " + x3 + " " + y3);
        }
    }

    static void Chercher_PT(List<string> Tableau, out List<string> table, int x1, int y1)
    {
        table = Tableau;

        for (int i = 0; i < table.Count; i++)
        {
            for (int j = 0; j < table[i].Length; j++)
            {
                if (table[i][j] == '0')
                {
                    Calcul_PT(table, j, i, out int x2, out int y2, out int x3, out int y3);
                    var sb = new StringBuilder(table[i]);
                    table[i] = sb.Replace('0', '.', j, 1).ToString();
                    if (x2 != -1)
                    {
                        Chercher_PT(Tableau, out table, x2, i);
                    }
                    if (y3 != -1)
                    {
                        Chercher_PT(Tableau, out table, j, y3);
                    }
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        int x1 = 0;
        int y1 = 0;
        var Tableau = new List<string>();

        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
            Tableau.Add(line);
        }
        Chercher_PT(Tableau, out List<string> table, x1, y1);
    }
}