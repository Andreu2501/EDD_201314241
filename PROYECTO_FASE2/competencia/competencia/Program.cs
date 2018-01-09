using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace competencia
{
    class Program
    {

        static void Main(string[] args)
        {

            long N = Int64.Parse(Console.ReadLine());//meto 111
            string cantidadN = N.ToString();

            string m = cantidadN.Substring(0, 1);
            long num = Convert.ToInt64(m);//obtengo el 1
            int n = cantidadN.Length;//3
            int letra0 = 96;
            int abe=96;

            //obteniendo el ascii
            for (int i = 1; i <= 26; i++)
            {
                abe = abe + 1;

            }
            for (int i = 1; i <= num; i++)
            {
                letra0 = letra0 + 1;

            }
            int Costo = abe * n+letra0;

            Console.WriteLine(Costo);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
        
    }
}