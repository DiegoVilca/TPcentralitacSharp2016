using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaSerializacion
{
    public interface ISerializable
    {
        string RutaDeArchivo
        {
            get;
            set;
        }

        bool Serializarse();

        bool DeSerializarse();
    }
}
