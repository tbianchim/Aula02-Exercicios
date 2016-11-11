using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Ex 03 - Escreva um programa que lê do console uma sequencia de N números (até o usuário digitar ESC) e imprime esses números em ordem crescente] */
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            bool fim;
            string buffer;
            List<int> lista = new List<int>();
            do
            {
                fim = false;
                buffer = "";
                Console.Write("\nInforme o próximo número (ESC para Sair): ");

                while (!fim)
                {
                    cki = Console.ReadKey(true);


                    if (cki.Key == ConsoleKey.Enter)
                    {
                        // Teclou enter                        
                        lista.Add(Int32.Parse(buffer));
                        fim = true;
                        break;
                    }

                    if (cki.Key == ConsoleKey.Escape)
                    {
                        // Teclou Esc
                        fim = true;
                        break;
                    }

                    if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3 || cki.Key == ConsoleKey.D4 || cki.Key == ConsoleKey.D5 || cki.Key == ConsoleKey.D6 || cki.Key == ConsoleKey.D7 || cki.Key == ConsoleKey.D8 || cki.Key == ConsoleKey.D9 || cki.Key == ConsoleKey.D0)
                    {
                        buffer = String.Concat(buffer, cki.KeyChar);
                        Console.Write(cki.KeyChar);
                    }


                }



            } while (cki.Key != ConsoleKey.Escape);

            lista.Sort();
            Console.Write("\nLista: ");
            for(int i=0; i<lista.Count; i++)
            {
                Console.Write(" {0} ;", lista.ElementAt(i));
            }
            Console.WriteLine();
        }
    }
}
