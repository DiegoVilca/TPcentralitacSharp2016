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
        public float CostoLlamada { get { return this.CalcularCosto();  } }


        #endregion Propiedades


        #region Constructores

        public Provincial(string origen, Franja miFranja, float duracion, string destino) :base(origen, destino, duracion)
        {
            base._nroOrigen = origen;
            base._duracion = duracion;
            base._nroDestino = destino;
            this._franjaHoraria = miFranja;
        }

        public Provincial(Franja miFranja, Llamada unaLlamada) :this(unaLlamada.NroOrigen, miFranja, unaLlamada.Duracion, unaLlamada.NroDestino)
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
            float costo = 0;

            switch (this._franjaHoraria)
            {
                case Franja.Franja_1:   costo = 0.99f * base.Duracion;
                    break;
                case Franja.Franja_2:   costo = 1.25f * base.Duracion;
                    break;
                case Franja.Franja_3:   costo = 0.66f * base.Duracion;
                    break;
                
            }

            return costo;
            
        }


        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.Mostrar();
            sb.AppendLine("Franja horaria: "+ this._franjaHoraria);
            sb.AppendLine("Costo de la llamada: " + this.CostoLlamada);
            Console.WriteLine(sb.ToString());
        }


        #endregion Metodos

    }
}
