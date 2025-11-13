using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Eventos;
using Dominio.Puertos;
using MassTransit;

namespace Infraestructura.Event_Bus.Consumidores
{
    public class Registrar_Accion_Consumidor : IConsumer<Registrar_Accion_Evento>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IUsuario_Repositorio repo;

        // Constructor 
        public Registrar_Accion_Consumidor(IPublishEndpoint publishEndpoint, IUsuario_Repositorio usuario_Repositorio)
        {
            _publishEndpoint = publishEndpoint;
            repo = usuario_Repositorio;
        }

        public async Task Consume(ConsumeContext<Registrar_Accion_Evento> context)
        {
            var mensaje = context.Message;
            await repo.Registrar_En_Historial( mensaje.id,mensaje.descripcion, mensaje.hora, mensaje.id_usuario);
        }
    }
}
