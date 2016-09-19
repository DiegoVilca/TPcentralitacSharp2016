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
        //Retornara el precio que se calculara en el metodo CalcularCosto
        public float CostoLlamada { get { return this.CalcularCosto();  } }


        #endregion


        #region Constructores
        

        public Local(string origen, float duracion, string destino, float costo) :base (origen, destino, duracion)
        {
            base._nroOrigen = origen;
            base._duracion = duracion;
            base._nroDestino = destino;
            this._costo = costo;
        }

        public Local(Llamada unaLlamada, float costo) :this(unaLlamada.NroOrigen, unaLlamada.Duracion, unaLlamada.NroDestino, costo)
        {
        }

        #endregion Constructores


        #region Metodos

        private float CalcularCosto()
        {
            //Retornara el valor de la llamada a partir de la
            //duracion y el costo de la misma.

            return base.Duracion * this._costo;
        }


        public void Mostrar()
        {
            //Mostrara ademas de los atributos de la clase base, 
            //solo la propiedad CostoLlamada, utiliza stringbuilder

            StringBuilder sb = new StringBuilder();

            base.Mostrar();
            sb.AppendLine("Costo de la llamada: "+ this.CostoLlamada);
            Console.WriteLine(sb.ToString());
        }


        #endregion Metodos



    }
}
