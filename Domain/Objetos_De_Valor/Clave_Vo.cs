using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public  class Clave_Vo
    {
        public string valor_Clave { get; private set; }
        public Clave_Vo(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave) || clave.Length < 6) throw new ArgumentException("La clave no es valida. Debe tener al menos 6 caracteres.");
            valor_Clave = clave;
        }
    }
}
