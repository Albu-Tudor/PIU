using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaAcasa2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.Write("Linia de comanda nu " +
                    "contine argumente");
            else
            {
                int first_letter_int;
                int row;
                int[] nr_elementsOnRow = new int[26];
                Console.WriteLine("Numarul de argumente este: {0}", args.Length);

                string[][] vector = new string[26][];
                for (int contor = 0; contor < 26; contor++)
                    vector[contor] = new string[args.Length];

                for (int contor = 0; contor < 26; contor++)
                    nr_elementsOnRow[contor] = 0;

                foreach (string param in args)
                {
                    first_letter_int = Convert.ToInt32(param[0]);
                    if ((65 <= first_letter_int) && (first_letter_int <= 90))
                    {
                        row = first_letter_int - 65;
                        vector[row][nr_elementsOnRow[row]] = param;
                        nr_elementsOnRow[row] = nr_elementsOnRow[row] + 1;
                    }
                    else if ((97 <= first_letter_int) && (first_letter_int <= 122))
                    {
                        row = first_letter_int - 97;
                        vector[row][nr_elementsOnRow[row]] = param;
                        nr_elementsOnRow[row] = nr_elementsOnRow[row] + 1;
                    }
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    if (nr_elementsOnRow[i] != 0)
                    {
                        for (int j = 0; j < nr_elementsOnRow[i]; j++)
                            Console.Write("{0} ", vector[i][j]);
                        Console.WriteLine();
                    }
                         
                }
            }
            Console.ReadKey();
        }
    }
}
