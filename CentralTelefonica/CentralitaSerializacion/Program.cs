using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CentralitaSerializacion
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

            miCentralita.RutaDeArchivo = @"C:\Users\Administrador\Desktop";


            //Antes de deserializar verificar que no halla xml creado
            try
            {
                miCentralita.DeSerializarse();
                Console.WriteLine("Se ha deserializado con exito");
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine("Mensaje: "+ex.Message);
                Console.WriteLine("Error interno: "+ ex.ExcepcionInterna.Message); 
                Console.WriteLine("Clase del error: "+ex.NombreClase);
                Console.WriteLine("Metodo del error: "+ ex.NombreMetodo);
                

            }

            Console.WriteLine("\n ");

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
            //Reutiliza llamadaDos
            miCentralita += llamadaCuatro;
            Console.WriteLine(miCentralita.ToString());

            Console.WriteLine("//=====================================");

            //Ordeno llamadas por duracion asc y muestro
            miCentralita.OrdenarLlamadas();
            Console.WriteLine(miCentralita.ToString());

            //Serializo

            try
            {
                miCentralita.Serializarse();

                Console.WriteLine("Se ha serializado con exito");
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine("Mensaje: " + ex.Message);
                Console.WriteLine("Error interno: " + ex.ExcepcionInterna.Message);
                Console.WriteLine("Clase del error: " + ex.NombreClase);
                Console.WriteLine("Metodo del error: " + ex.NombreMetodo);
            }
            
            //Recupero txt
            Console.WriteLine("//========================================");
            Console.WriteLine("Leo el archivo txt");
            Console.WriteLine();
            Console.WriteLine(miCentralita.LeerArchivo());

            Console.ReadKey();
        }
    }
}
