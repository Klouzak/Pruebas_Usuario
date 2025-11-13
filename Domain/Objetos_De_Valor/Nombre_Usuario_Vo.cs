using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public class Nombre_Usuario_Vo
    {
        public string valor_Nombre_Usuario { get; private set; }
        public Nombre_Usuario_Vo(string nombre_usuario)
        {
            if (string.IsNullOrWhiteSpace(nombre_usuario) || nombre_usuario.Length < 3) throw new ArgumentException("El nombre de usuario no es válido. Debe tener al menos 3 caracteres.");
            valor_Nombre_Usuario = nombre_usuario;
        }
    }
}
