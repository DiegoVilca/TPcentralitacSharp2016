using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Llamada
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



        #region Constructor

        public Llamada(string origen, string destino, float duracion) 
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        #endregion Constructor



        #region Metodos

        public void Mostrar()
        { 
            //Utiliza stringbuilder
        }



        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        {
            //Sera utilizado en el metodo Sort de la lista
            //generica del mismo tipo (en la clase centralita)
            //return provisional
            return 1;
        }


        #endregion Metodos


    }
}
