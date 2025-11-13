using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dominio.Puertos;
using Microsoft.Extensions.Configuration;

namespace Infraestructura.Image_Service
{
    public class Servicio_Imagen:I_Imagen_Servicio
    {

        private readonly CloudinaryDotNet.Cloudinary _cloudinary;

        public Servicio_Imagen(IConfiguration configuracion)
        {
            var account = new Account(
                configuracion["CloudDinary:Cloud_Name"],
                configuracion["CloudDinary:Api_Key"],
                configuracion["CloudDinary:Api_Secret"]);

            _cloudinary = new CloudinaryDotNet.Cloudinary(account);
        }

        public async Task<string> Subir_Imagen(byte[] imagenBytes)
        {
            using var stream = new MemoryStream(imagenBytes);
            var Guid_File = Guid.NewGuid().ToString();

            var Cargar_Parametros = new ImageUploadParams
            {
                File = new FileDescription(Guid_File, stream),UseFilename = true, UniqueFilename = true,
                Overwrite = false, PublicId = Guid_File,
                Folder = "Fotos de Perfil" 
            };

            var result = await _cloudinary.UploadAsync(Cargar_Parametros);       // Subir a Cloudinary
            return result.SecureUrl.ToString();   //Retornar la URL
        }
    }
}
