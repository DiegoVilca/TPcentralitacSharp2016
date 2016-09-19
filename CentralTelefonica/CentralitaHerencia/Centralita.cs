using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;



        #region Propiedades

        //public float GananciaPorlocal
        //{ get { ;} }

        //public float GananciaporProvincial
        //{ get { ;} }

        //public float GananciaTotal
        //{ get { ;} }

        //public List<Llamada> Llamadas
        //{ get { ;} }


        #endregion Propiedades


        #region Constructores

        public Centralita()
        {
            _listaDeLlamadas = new List<Llamada>();
        }

        public Centralita( string nombreEmpresa) :this()
        {
            this._razonSocial = nombreEmpresa;
        }

        #endregion Constructores


        #region Metodos

        private float CalcularGanancia( TipoLlamada tipo)
        {
            //Retorna el valor de lo recaudado, segun el criterio elegido
            //return provisional
            return 1;
        }

        public void Mostrar()
        { 
            //Mostrara la razon social, la ganancia total
            //ganancia por llamados locales y provinciales y el
            //detalle de las llamadas realizadas
        }

        public void OrdenarLlamadas()
        { 
        
        }

        #endregion Metodos



    }
}
