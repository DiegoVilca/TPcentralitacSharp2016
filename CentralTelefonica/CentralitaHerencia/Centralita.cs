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

        public float GananciaPorlocal
        { get { ;} }

        public float GananciaporProvincial
        { get { ;} }

        public float GananciaTotal
        { get { ;} }

        public List<Llamada> Llamadas
        { get { ;} }


        #endregion Propiedades


        #region Constructores

        public Centralita()
        { 
        }

        public Centralita( string nombreEmpresa)
        { 
            
        }

        #endregion Constructores


        #region Metodos

        private float CalcularGanancia( TipoLlamada tipo)
        {
            //return provisional
            return 1;
        }

        public void Mostrar()
        { 
        }

        public void OrdenarLlamadas()
        { 
        
        }

        #endregion Metodos



    }
}
