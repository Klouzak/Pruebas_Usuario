using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Eventos
{
    public  class Registrar_Accion_Evento
    {
        public Guid id { get; set; }
        public string descripcion { get; set; }
        public DateTime hora { get; set; }
        public Guid id_usuario { get; set; }

        // connstructor 

        public Registrar_Accion_Evento() { }

        public Registrar_Accion_Evento(Guid id, string descripcion, DateTime hora, Guid id_usuario)
        { this.id = id; this.descripcion = descripcion; this.hora = hora; this.id_usuario = id_usuario;
       }

    }
}
