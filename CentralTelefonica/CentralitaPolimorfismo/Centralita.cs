using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;



        #region Propiedades

        public float GananciaPorlocal
        { get { return CalcularGanancia(TipoLlamada.Local); } }

        public float GananciaporProvincial
        { get { return CalcularGanancia(TipoLlamada.Provincial); } }

        public float GananciaTotal
        { get { return CalcularGanancia(TipoLlamada.Todas); } }

        public List<Llamada> Llamadas
        { get { return this._listaDeLlamadas; } }


        #endregion Propiedades


        #region Constructores

        public Centralita()
        {
            _listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
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

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this._listaDeLlamadas.Add(nuevaLlamada);
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
            if (central == nuevaLlamada)
            {
                Console.WriteLine("La llamada ya se encuentra registrada en la central.");
                
                return central;
            }

            central.AgregarLlamada(nuevaLlamada);
            return central;
        }

        #endregion



    }
}
