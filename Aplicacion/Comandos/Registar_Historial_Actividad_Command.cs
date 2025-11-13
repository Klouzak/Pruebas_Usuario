using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO;
using MediatR;

namespace Aplicacion.Comandos
{
    public class Registar_Historial_Actividad_Command: IRequest<Guid>
    {
        public Registar_Historial_Actividad_Dto dto { get; set; }
        public Registar_Historial_Actividad_Command(Registar_Historial_Actividad_Dto d) {dto = d; }
    }
}
