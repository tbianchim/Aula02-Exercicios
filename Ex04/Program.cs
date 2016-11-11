using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Ex 04Usando um arquivo CSV com os horários e números dos ônibus. 
             * Escreva um programa que retorna os números de ônibus dentro de um determinado intervalo (hora inicial e hora final)
 */
            using (var streamReader = File.OpenText("horarios_onibus.csv"))
            {

                Console.Write("\nInforme Hora Inicial: ");
                DateTime horaini = DateTime.ParseExact(Console.ReadLine(), "H:mm", CultureInfo.InvariantCulture);
                Console.Write("\nInforme Hora Final: ");
                DateTime horafim = DateTime.ParseExact(Console.ReadLine(), "H:mm", CultureInfo.InvariantCulture);

                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    var linha = streamReader.ReadLine();
                    if (linha != null)
                    {
                        var arrayString = linha.Split(',');                        

                        DateTime hora = DateTime.ParseExact(arrayString[0], "H:mm",CultureInfo.InvariantCulture);

                        if (hora >= horaini && hora <= horafim)
                        {
                            Console.WriteLine("{0} / {1}", hora.TimeOfDay, arrayString[1]);
                        }
                    }
                }

                streamReader.Close();
            }

        }
    }
}
