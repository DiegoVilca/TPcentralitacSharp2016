using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {

        protected Franja _franjaHoraria;


        #region Propiedades

        //Retornara el precio que se calculara en el metodo CalcularCosto
        public float CostoLlamada { get; }


        #endregion Propiedades


        #region Constructores

        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(origen, destino, duracion)
        {
            base._nroOrigen = origen;
            base._duracion = duracion;
            base._nroDestino = destino;
            this._franjaHoraria = miFranja;
        }

        public Provincial(Franja miFranja, Llamada unaLlamada) 
        { 
            
        }

        #endregion Constructores


        #region Metodos

        private float CalcularCosto()
        { 
            //Retornara el valor de la llamada a partir de la
            //duracion y el costo de la misma.
            //Valores:
            //Franja_1: 0.99, Franja_2: 1.25, Franja_3 : 0.66
            //return provisional
            return 1;
        }


        public void Mostrar()
        { 
            //Mostrara ademas de los atributos de la clase base,
            //_frnajaHoraria y CostoLlamada, utiliza stringbuilder.
        }


        #endregion Metodos

    }
}
