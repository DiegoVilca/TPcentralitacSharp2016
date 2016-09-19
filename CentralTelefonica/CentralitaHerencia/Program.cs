using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
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

            miCentralita.Llamadas.Add(llamadaUno);
            miCentralita.Llamadas.Add(llamadaDos);
            miCentralita.Llamadas.Add(llamadaTres);
            miCentralita.Llamadas.Add(llamadaCuatro);

            miCentralita.Mostrar();

            miCentralita.OrdenarLlamadas();

            miCentralita.Mostrar();

            Console.ReadKey();



        }
    }
}
