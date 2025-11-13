using Aplicacion.Comandos;
using Aplicacion.DTO;
using Dominio.Puertos;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Api_Presentacion.Controllers
{
    [ApiController]
    [Route("Micro_servicio/Usuarios")] // Ruta inicial de cada uno de los endpoints

    public class Controlador: ControllerBase
    {
        private readonly IMediator _mediador;
        private readonly I_Imagen_Servicio _image_service;

        public Controlador(IMediator mediador, I_Imagen_Servicio image_service)
        {_mediador = mediador;_image_service = image_service; }


        /// <summary>
        /// /   Crear Usuario   
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("Crear_Usuario")]
        public async Task<IActionResult> Crear_Usuario([FromBody] Crear_Usuario_DTO dto)
        {

            try
            {
                var comando = new Crear_Usuario_Command(dto);
                var resultado = await _mediador.Send(comando);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = "Error al crear usuario",
                    mensaje = e.Message
                });
            }
        }

        /// <summary>k,;
        /// Modificar Usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("Modificar_Usuario")]
        public async Task<IActionResult> Modificar_Usuario([FromBody] Modificar_datos_Usuario_DTO dto)
        {

            try
            {
                var comando = new Modificar_datos_Usuario_Command(dto);
                var resultado = await _mediador.Send(comando);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = "Error al crear usuario",
                    mensaje = e.Message
                });
            }
        }



        /// <summary>
        ///     Actualizar Imagen de Perfil
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("Actualizar_Imagen_Perfil")]
        public async Task<IActionResult> Actualizar_Imagen_Perfil([FromForm] Actualizar_Imagen_Perfil_DTO dto)
        {
            try
            {
                byte[] imagenBytes;

                // El IFormFile  se convierte a byte[] o Stream en este punto.
                using (var memoryStream = new MemoryStream())
                {await dto.Imagen_Perfil.CopyToAsync(memoryStream); imagenBytes = memoryStream.ToArray(); }

                // Subir imagen al servicio de imagenes
                var url_Imagen = await _image_service.Subir_Imagen(imagenBytes);

                // Crear y enviar el comando para actualizar la imagen de perfil
                var comando = new Actualizar_Imagen_Perfil_Command(dto.Id_Usuario, url_Imagen);
                var resultado = await _mediador.Send(comando);


                return Ok(url_Imagen);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = "Error al actualizar imagen de perfil",
                    mensaje = e.Message
                });
            }
        }


        // Registrar en historial de actividad 

        [HttpPost("Registrar_Historial_Actividad")]
        public async Task<IActionResult> Registrar_Historial_Actividad([FromBody] Registar_Historial_Actividad_Dto dto)
        {
            try
            {
                var command = new Registar_Historial_Actividad_Command(dto);
                var respuesta= await _mediador.Send(command);
                
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(new
                { error = "Error al registrar historial de actividad", mensaje = e.Message });
            }
        }



    }
}
