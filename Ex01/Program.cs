using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    public struct Coord
    {
        public int x, y;

        public Coord(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    public struct Par<T1, T2>
        where T1:struct
        where T2:struct
    {
        public T1 coord1;
        public T2 coord2;

        public Par(T1 c1, T2 c2)
        {
            coord1 = c1;
            coord2 = c2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Exercicio 01 - Crie uma struct Par<T1,T2> que permita o relacionamento de dois objetos. 
            * Esses tipos precisam ser obrigatoriamento structs */

            var c1 = new Coord(123, 456);
            var c2 = new Coord(789, 528);

            var par1 = new Par<Coord, Coord>(c1,c2);

            Console.WriteLine("Par: ({0},{1}),({2},{3})", par1.coord1.x, par1.coord1.y, par1.coord2.x, par1.coord2.y);

        }
    }
}
