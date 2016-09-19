using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local : Llamada
    {

        protected float _costo;

        #region Propiedades
        //Retornara el precio que se calculara el el metodo CalcularCosto
        public float CostoLlamada { get; }


        #endregion


        #region Constructores
        
        public Local(Llamada unaLlamada, float costo) 
        { 
        }

        public Local(string origen, float duracion, string destino, float costo) :base (origen, destino, duracion)
        {
            base._nroOrigen = origen;
            base._duracion = duracion;
            base._nroDestino = destino;
            this._costo = costo;
        }

        #endregion Constructores


        #region Metodos

        private float CalcularCosto()
        {
            //Retornara el valor de la llamada a partir de la
            //duracion y el costo de la misma.
            //Return provisional
            return 1;
        }


        public void Mostrar()
        {
            //Mostrara ademas de los atributos de la clase base, 
            //solo la propiedad, CostoLlamada, utiliza stringbuilder
        }


        #endregion Metodos



    }
}
