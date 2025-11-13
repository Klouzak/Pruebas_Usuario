using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public  class Id_Usuario_Vo
    {
        public Guid valor_Id_Usuario { get; private set; }

        public Id_Usuario_Vo(Guid id_usuario)
        {
            if (id_usuario == Guid.Empty) throw new ArgumentException("El Id de usuario no cumple con el formato requerido ");
            valor_Id_Usuario = id_usuario;
        }
    }
}
