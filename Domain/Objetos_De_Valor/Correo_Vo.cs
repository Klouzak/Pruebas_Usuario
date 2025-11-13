using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public class Correo_Vo
    {
        public string valor_Correo { get; private set; }
        public Correo_Vo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || !valor.Contains("@")) throw new ArgumentException("El email no es válido.");
            valor_Correo = valor;
        }

    }
}
