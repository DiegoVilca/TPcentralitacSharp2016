using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaPolimorfismo
{
    public abstract class Llamada
    {
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;



        #region Propiedades
        public float Duracion
        {
            get { return this._duracion; }
        }

        public string NroDestino
        {
            get { return this._nroDestino; }
        }

        public string NroOrigen
        {
            get { return this._nroOrigen; }
        }

        #endregion Propiedades

        public abstract float CostoLlamada
        {
            get;

        }



        #region Constructor

        public Llamada(string origen, string destino, float duracion)
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        #endregion Constructor



        #region Metodos

        protected virtual string Mostrar()
        {
            //Utiliza stringbuilder
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Numero de origen: " + this._nroOrigen);
            sb.AppendLine("Numero de destino: " + this._nroDestino);
            sb.Append("Duracion: " + this._duracion);

            return sb.ToString();
        }


        //ORDENA POR DURACION ASC
        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        {
            //Sera utilizado en el metodo Sort de la lista
            //generica del mismo tipo (en la clase centralita)

            return uno.Duracion.CompareTo(dos.Duracion);
        }


        #endregion Metodos

        #region sobrecarga operadores
        
        public static bool operator ==(Llamada uno, Llamada dos)
        {
            if (uno.Equals(dos))
            {
                if (uno.NroOrigen == dos.NroOrigen && uno.NroDestino == dos.NroDestino)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Llamada uno, Llamada dos)
        {
            return !(uno == dos);
        }
    
        #endregion

    }
}
