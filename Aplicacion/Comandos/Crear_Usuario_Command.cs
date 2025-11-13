using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO;
using MediatR;

namespace Aplicacion.Comandos
{
    public class Crear_Usuario_Command : IRequest<Guid>
    {
        public Crear_Usuario_DTO dto { get; set; }
        public Crear_Usuario_Command(Crear_Usuario_DTO dto) {this.dto = dto; }
    }
}
