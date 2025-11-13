using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Comandos;
using Aplicacion.Eventos;
using Dominio.Puertos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Handlers
{
    public class Actualizar_Imagen_Perfil_Handler : IRequestHandler<Actualizar_Imagen_Perfil_Command, Guid>

    {

        private readonly IUsuario_Repositorio _usuario_repositorio;
        private readonly ILogger<Crear_Usuario_Handler> _logger;
        private readonly MassTransit.IPublishEndpoint _publish;

        // Constructor
        public Actualizar_Imagen_Perfil_Handler(IUsuario_Repositorio usuario_repositorio, ILogger<Crear_Usuario_Handler> logger, MassTransit.IPublishEndpoint publish)
        {_usuario_repositorio = usuario_repositorio; _logger = logger;_publish = publish;}


        public async Task<Guid> Handle(Actualizar_Imagen_Perfil_Command request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Iniciando proceso de actualización de imagen de perfil ");
            var Url = request.Imagen_URL;
            var guid_Usuario = request.Id_Usuario;

            await _usuario_repositorio.Actualizar_Foto_Perfil( guid_Usuario,Url);

            //Registro en el historial de actividades 

            var evento = new Registrar_Accion_Evento(Guid.NewGuid(), "Actualizacion de Foto de Perfil", DateTime.UtcNow,
                guid_Usuario);
            await _publish.Publish(evento, cancellationToken);

            return request.Id_Usuario;
        }


    }
}
