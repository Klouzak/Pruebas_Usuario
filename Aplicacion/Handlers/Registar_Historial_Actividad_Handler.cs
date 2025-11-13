using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Comandos;
using Dominio.Puertos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Handlers
{
    public class Registar_Historial_Actividad_Handler: IRequestHandler<Registar_Historial_Actividad_Command,Guid>
    {

        private readonly IUsuario_Repositorio _usuario_repositorio;
        private readonly ILogger<Crear_Usuario_Handler> _logger;

        // Constructor
        public Registar_Historial_Actividad_Handler(IUsuario_Repositorio usuario_repositorio, ILogger<Crear_Usuario_Handler> logger)
        { _usuario_repositorio = usuario_repositorio; _logger = logger; }

        public async Task<Guid> Handle(Registar_Historial_Actividad_Command request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando proceso de registro de historial de actividad ");
           
            var dto_Recibido = request.dto;
            var id_historial= Guid.NewGuid();
            
            await _usuario_repositorio.Registrar_En_Historial(id_historial, dto_Recibido.descripcion,dto_Recibido.hora, dto_Recibido.id_usuario);
            return id_historial;
        }


    }
}
