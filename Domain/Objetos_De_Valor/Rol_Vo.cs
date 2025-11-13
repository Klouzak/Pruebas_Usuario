using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public class Rol_Vo
    {
        public string valor_Rol { get; private set; }
        public Rol_Vo(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol) || rol.Length < 3) throw new ArgumentException("El rol no es válido. Debe tener al menos 3 caracteres.");
            valor_Rol = rol;
        }
    }
}
