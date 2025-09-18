using System;
using System.Collections.Generic;

class ChessKnights
{
    static void Main()
    {
        Console.WriteLine("Ingrese ubicación de los caballos: ");
        string input = Console.ReadLine();
        string[] positions = input.Split(',');

        List<string> knights = new List<string>();
        foreach (string position in positions)
        {
            knights.Add(position.Trim());
        }

        Dictionary<string, List<string>> conflicts = new Dictionary<string, List<string>>();

        foreach (string knight in knights)
        {
            conflicts[knight] = new List<string>();

            int x1 = knight[0] - 'A';
            int y1 = knight[1] - '1';

            foreach (string otherKnight in knights)
            {
                if (knight != otherKnight)
                {
                    int y2 = otherKnight[1] - '1';
                    int x2 = otherKnight[0] - 'A';
                    

                    if (Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1 ||
                        Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2)
                    {
                        conflicts[knight].Add(otherKnight);
                    }
                }
            }
        }

        foreach (var knight in knights)
        {
            List<string> knightConflicts = conflicts[knight];
            string positionFormatted = $"{knight[1]}{knight[0]}";
            Console.Write($"Analizando Caballo en {positionFormatted} => ");

            if (knightConflicts.Count > 0)
            {
                knightConflicts.Sort((a, b) =>
                {
                    int colComparison = a[0].CompareTo(b[0]);
                    return colComparison != 0 ? colComparison : a[1].CompareTo(b[1]);
                });

                foreach (var conflict in knightConflicts)
                {
                    Console.Write($"Conflicto con {conflict[1]}{conflict[0]} ");
                }
                Console.WriteLine();
            }
           
            else
            {
                Console.WriteLine();
            }
        }
    }
}
