using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Comandos;
using Aplicacion.Eventos;
using Dominio.Entidades;
using Dominio.Objetos_De_Valor;
using Dominio.Puertos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Handlers
{
    public class Crear_Usuario_Handler : IRequestHandler<Crear_Usuario_Command,Guid>
    {
        private readonly IUsuario_Repositorio _usuario_repositorio;
        private readonly ILogger<Crear_Usuario_Handler> _logger;
        private readonly MassTransit.IPublishEndpoint _publish;

        // Constructor  
        public Crear_Usuario_Handler(IUsuario_Repositorio usuario_repositorio, ILogger<Crear_Usuario_Handler> logger, MassTransit.IPublishEndpoint publish)
        {_usuario_repositorio = usuario_repositorio; _logger = logger; _publish = publish; }


        public async Task<Guid> Handle(Crear_Usuario_Command request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando proceso de creación de usuario ");

            try
            {
                var dto_Recibido = request.dto;
                _logger.LogDebug("Datos del usuario a crear  Nombre: {Nombre}, Correo: {Correo}, Rol: {Rol}",
                     dto_Recibido.nombre, dto_Recibido.correo, dto_Recibido.Rol);

          
                var user = new Usuario(new Id_Usuario_Vo(dto_Recibido.id_usuario),
                    new Nombre_Usuario_Vo(dto_Recibido.nombre), new Apellido_Vo(dto_Recibido.apellido),
                    new Correo_Vo(dto_Recibido.correo), new Clave_Vo(dto_Recibido.clave), new Rol_Vo(dto_Recibido.Rol),
                    null);

                await _usuario_repositorio.Crear_Usuario(user);
                _logger.LogInformation("Usuario creado exitosamente ID: {UsuarioId}, Correo: {Correo}", dto_Recibido.id_usuario, dto_Recibido.correo);


                //Registro en el historial de actividades 

                var evento = new Registrar_Accion_Evento(Guid.NewGuid(), "Registro en la aplicacion", DateTime.UtcNow,
                    dto_Recibido.id_usuario);
                
                await _publish.Publish(evento, cancellationToken);

                return dto_Recibido.id_usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
