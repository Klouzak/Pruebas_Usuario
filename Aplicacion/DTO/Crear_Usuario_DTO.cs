using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO
{
    public class Crear_Usuario_DTO
    {
       public Guid id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string Rol { get; set; }

    }
}
