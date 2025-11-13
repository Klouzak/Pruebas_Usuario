using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos_De_Valor
{
    public class Imagen_URL_Vo
    {
        public string valor_Imagen_URL { get; private set; }
        public Imagen_URL_Vo(string imagenUrl)
        {
           /* if (string.IsNullOrWhiteSpace(imagenUrl) || !Uri.IsWellFormedUriString(imagenUrl, UriKind.Absolute))
            {throw new ArgumentException("La URL de la imagen no es válida  "); }*/
            valor_Imagen_URL = imagenUrl;
        }
    }
}
