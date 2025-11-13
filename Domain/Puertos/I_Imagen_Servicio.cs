using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Puertos
{
    public interface I_Imagen_Servicio
    {
        Task<string> Subir_Imagen(byte[] imagenBytes);
    }
}
