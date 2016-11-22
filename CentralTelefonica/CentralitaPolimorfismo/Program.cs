using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");

            Local llamadaUno = new Local("Avellaneda", 0.5f, "Banfield", 2.65f);
            Provincial llamadaDos = new Provincial("Lanus", Franja.Franja_1, 0.35f, "Cordoba");
            Local llamadaTres = new Local("Palermo", 0.75f, "Chacarita", 1.99f);
            Provincial llamadaCuatro = new Provincial(Franja.Franja_3, llamadaDos);

            miCentralita += llamadaUno;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");

            miCentralita += llamadaDos;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");
            
            miCentralita += llamadaTres;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");
            //Agrego llamada REPETIDA
            miCentralita += llamadaTres;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");
            
            miCentralita += llamadaCuatro;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");
            
            //Ordeno llamadas por duracion asc y muestro
            miCentralita.OrdenarLlamadas();
            Console.WriteLine(miCentralita.ToString());
            

            Console.ReadKey();
        }
    }
}
