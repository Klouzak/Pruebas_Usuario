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
    public class Modificar_datos_Usuario_Handler : IRequestHandler<Modificar_datos_Usuario_Command, string>
    {
        private readonly IUsuario_Repositorio _usuario_repositorio;
        private readonly ILogger<Crear_Usuario_Handler> _logger;
        private readonly MassTransit.IPublishEndpoint _publish;

        // Constructor
        public Modificar_datos_Usuario_Handler(IUsuario_Repositorio usuario_repositorio, ILogger<Crear_Usuario_Handler> logger, MassTransit.IPublishEndpoint publish)
        {_usuario_repositorio = usuario_repositorio;_logger = logger;_publish = publish;}

        public async Task<string> Handle(Modificar_datos_Usuario_Command request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando proceso de modificación de datos de usuario ");
            try
            {
                //Recibir dto
                var dto_Recibido = request.dto;
                _logger.LogDebug("Datos del usuario a modificar - Nombre: {Nombre}, Nombre: {Apellido}, Correo: {Correo}",
                     dto_Recibido.nombre, dto_Recibido.apellido, dto_Recibido.correo);

                //Modificar datos
                await _usuario_repositorio.Modificar_datos_Usuario(dto_Recibido.nombre, dto_Recibido.apellido, 
                    dto_Recibido.correo, dto_Recibido.id_usuario);

                _logger.LogInformation("Datos del usuario modificados exitosamente - Nombre: {Nombre}, Correo: {Correo}", 
                    dto_Recibido.nombre, dto_Recibido.correo);

                //Registro en el historial de actividades 

                var evento = new Registrar_Accion_Evento(Guid.NewGuid(), "Actualizacion de Foto de Perfil", DateTime.UtcNow,
                    dto_Recibido.id_usuario);
                await _publish.Publish(evento, cancellationToken);


                return "Proceso de modificacion Exitoso";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
