using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Ex 02 - Escreva um programa que remova todos os numero negativos da 
             * seguinte sequencia [19,-10, 12, -6, -3, 34, -2, 5] */

            var lista = new List<int>();
            lista.Add(19);
            lista.Add(-10);
            lista.Add(12);
            lista.Add(-6);
            lista.Add(-3);
            lista.Add(34);
            lista.Add(-2);
            lista.Add(5);

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] < 0)
                {
                    lista.RemoveAt(i);
                    i--;
                }
            }
            Console.Write("Lista: ");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write("{0} / ",lista[i]);
            }
            Console.WriteLine();

        }
    }
}
