using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor

{
    public class Apellido_Vo
    {
        public string valor_Apellido { get; private set; }
        public Apellido_Vo(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 2) throw new ArgumentException("El apellido no es válido. Debe tener al menos 2 caracteres.");
            valor_Apellido = apellido;
        }
    }
}
