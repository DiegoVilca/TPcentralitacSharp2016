using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace CentralitaSerializacion
{
    [XmlInclude(typeof(Local))]
    [XmlInclude(typeof(Provincial))]
    //[XmlInclude(typeof(Llamada))]
    public class Centralita : ISerializable
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        private string _ruta;



        #region Propiedades

        public float GananciaPorlocal
        { get { return CalcularGanancia(TipoLlamada.Local); } }

        public float GananciaporProvincial
        { get { return CalcularGanancia(TipoLlamada.Provincial); } }

        public float GananciaTotal
        { get { return CalcularGanancia(TipoLlamada.Todas); } }

        //=================================================

        // Propiedades publicas para xml.

        public List<Llamada> Llamadas
        {   get { return this._listaDeLlamadas; }

            set { this._listaDeLlamadas = value; } 
        }

        public string RazonSocial
        {
            get
            {
                return this._razonSocial;
            }
            set
            {
                this._razonSocial = value;
            }
        }

        public string RutaDeArchivo
        {
            get
            {
                return this._ruta;
            }
            set
            {
                this._ruta = value;
            }
        }
        //================================================
        #endregion Propiedades

        


        #region Constructores

        public Centralita()
        {
            _listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this.RazonSocial = nombreEmpresa;
        }

        #endregion Constructores


        #region Metodos

        private float CalcularGanancia(TipoLlamada tipo)
        {
            //Retorna el valor de lo recaudado, segun el criterio elegido

            float ganancia = 0;
            float gananciaLocal = 0;
            float gananciaProvincial = 0;

            Local ganaciaL;
            Provincial gananciaP;


            switch (tipo)
            {
                case TipoLlamada.Local:

                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Local))
                        {
                            ganaciaL = (Local)item;

                            gananciaLocal += ganaciaL.CostoLlamada;
                        }
                    }

                    ganancia = gananciaLocal;

                    break;

                case TipoLlamada.Provincial:

                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Provincial))
                        {
                            gananciaP = (Provincial)item;

                            gananciaProvincial += gananciaP.CostoLlamada;
                        }
                    }

                    ganancia = gananciaProvincial;

                    break;

                case TipoLlamada.Todas:

                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Local))
                        {
                            ganaciaL = (Local)item;

                            gananciaLocal += ganaciaL.CostoLlamada;
                        }
                        else if (item.GetType() == typeof(Provincial))
                        {
                            gananciaP = (Provincial)item;

                            gananciaProvincial += gananciaP.CostoLlamada;
                        }
                    }

                    ganancia = gananciaLocal + GananciaporProvincial;

                    break;

            }



            return ganancia;
        }

        //DEPRECATED por ToString()
        //public void Mostrar()
        //{
        //    //Mostrara la razon social, la ganancia total
        //    //ganancia por llamados locales y provinciales y el
        //    //detalle de las llamadas realizadas
        //    StringBuilder sb = new StringBuilder();
        //    //Local auxLocal;
        //    Provincial auxProvincial;

        //    sb.AppendLine("Razon Social: " + this._razonSocial);
        //    sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
        //    sb.AppendLine("Ganancia Local: " + this.GananciaPorlocal);
        //    sb.AppendLine("Ganancia Provincial: " + this.GananciaporProvincial);
        //    Console.WriteLine(sb.ToString());

        //    foreach (Llamada item in this._listaDeLlamadas)
        //    {
        //        if (item.GetType() == typeof(Local))
        //        {
        //            //auxLocal = (Local)item;
        //            //auxLocal.Mostrar();
        //            ((Local)item).Mostrar(); //Encerrando (Local)item entre parentesis no es necesario la creacion de auxLocal; lo mismo vale para auxProvincial
        //        }
        //        else if (item.GetType() == typeof(Provincial))
        //        {
        //            auxProvincial = (Provincial)item;
        //            auxProvincial.Mostrar();
        //        }
        //    }



        //}

        public override string ToString()
        {
            //Mostrara la razon social, la ganancia total
            //ganancia por llamados locales y provinciales y el
            //detalle de las llamadas realizadas
            StringBuilder sb = new StringBuilder();
            //Local auxLocal;
            Provincial auxProvincial;

            sb.AppendLine("Razon Social: " + this._razonSocial);
            sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
            sb.AppendLine("Ganancia Local: " + this.GananciaPorlocal);
            sb.AppendLine("Ganancia Provincial: " + this.GananciaporProvincial);


            foreach (Llamada item in this._listaDeLlamadas)
            {
                if (item.GetType() == typeof(Local))
                {
                    //auxLocal = (Local)item;
                    //auxLocal.Mostrar();

                    sb.AppendLine(((Local)item).ToString());
                }
                else if (item.GetType() == typeof(Provincial))
                {
                    sb.AppendLine(((Provincial)item).ToString());
                }
            }

            return sb.ToString();
        }

        //ORDENA LLAMADAS con SORT
        public void OrdenarLlamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        //---------------------------------------------------------------
        

        public bool Serializarse()
        {

            bool bandera = false;

            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(this.RutaDeArchivo +@"\Centralita.xml", Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Centralita));

                    serializador.Serialize(escritor, this);

                    bandera = true;
                }


            }
            catch (Exception ex)
            {

                throw new CentralitaException("Error, no se ha podido serializar.", "Centralita", "Serializarse()", ex);
            }

            return bandera;
        }

        public bool DeSerializarse()
        {
            bool bandera = false;

            try
            {
                using (XmlTextReader lector = new XmlTextReader(this.RutaDeArchivo + @"\Centralita.xml"))
                {
                    XmlSerializer deserializador = new XmlSerializer(typeof(Centralita));

                    Centralita nuevaCentralita = (Centralita)deserializador.Deserialize(lector);

                    this._listaDeLlamadas = nuevaCentralita._listaDeLlamadas;
                    this._razonSocial = nuevaCentralita._razonSocial;
                    this._ruta = nuevaCentralita._ruta;

                    bandera = true;
                }
            }
            catch (Exception ex)
            {

                throw new CentralitaException("Error, no se ha podido deserializar", "Centralita", "DeSerializarse()", ex);
            }

            return bandera;
        }


        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            
                try
                {
                    this._listaDeLlamadas.Add(nuevaLlamada);
                    this.GuardarEnArchivo(nuevaLlamada, true);
                }
                catch (CentralitaException ex)
                {
                    Console.WriteLine("Mensaje: " + ex.Message);
                    Console.WriteLine("Error interno: " + ex.ExcepcionInterna.Message);
                    Console.WriteLine("Clase del error: " + ex.NombreClase);
                    Console.WriteLine("Metodo del error: " + ex.NombreMetodo);
                }
                

        }

        private bool GuardarEnArchivo(Llamada unaLlamada, bool agrego)
        {

            bool bandera = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(this._ruta + @"\Llamadas.txt", agrego))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Datos de la llamada \n");
                    sb.AppendLine("Fecha de la llamada: " + DateTime.Now.ToLongTimeString());
                    sb.AppendLine(unaLlamada.ToString());

                    escritor.WriteLine(sb.ToString());

                    bandera = true;
                }
            }
            catch (Exception ex)
            {

                throw new CentralitaException("Error al guardar el archivo.", "Centralita", "GuardarEnArchivo()", ex);
            }

            return bandera;
        }

        public string LeerArchivo()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader lector = new StreamReader(this._ruta + @"\Llamadas.txt"))
                {
                    while (!lector.EndOfStream)
                    {
                        sb.AppendLine(lector.ReadLine());
                    }
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return sb.ToString();
        
        }

        #endregion Metodos

        #region Sobrecargas

        public static bool operator ==(Centralita central, Llamada nuevaLlamada)
        {


            foreach (Llamada item in central._listaDeLlamadas)
            {
                if (item == nuevaLlamada)
                {
                    return true;
                }
            }

            return false;

        }

        public static bool operator !=(Centralita central, Llamada nuevaLlamada)
        {
            return !(central == nuevaLlamada);
        }

        public static Centralita operator +(Centralita central, Llamada nuevaLlamada)
        {

            try
            {
                if (central == nuevaLlamada)
                {
                    throw new CentralitaException("Error, la llamada ya se encuentra registrada", "Centralita", "Sobrecarga operador +");
                }
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine("Mensaje: " + ex.Message);
                Console.WriteLine("Clase del error: " + ex.NombreClase);
                Console.WriteLine("Metodo del error: " + ex.NombreMetodo);
                Console.WriteLine(" ");
                return central;
                
            }
            

            central.AgregarLlamada(nuevaLlamada); //Se crea el txt con la nueva llamada
            return central;
        }

        #endregion

       




       
    }
}