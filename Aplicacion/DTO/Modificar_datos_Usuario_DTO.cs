using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO
{
    public class Modificar_datos_Usuario_DTO
    {
        public string? nombre { get; set; } public string? apellido { get; set; }
        public string? correo { get; set; } public Guid id_usuario { get; set; }
    }
}
