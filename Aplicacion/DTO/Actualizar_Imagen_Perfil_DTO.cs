using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Aplicacion.DTO
{
    public  class Actualizar_Imagen_Perfil_DTO
    {
        public IFormFile Imagen_Perfil { get; set; }
        public Guid Id_Usuario { get; set; }
    }
}
