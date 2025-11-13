using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO;
using Aplicacion.Eventos;
using Dominio.Objetos_De_Valor;
using Dominio.Puertos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class Usuario_Repositorio  : IUsuario_Repositorio
    {

        private readonly Db_Context _context;

        public Usuario_Repositorio(Db_Context context) {_context = context; }

        /// <summary>
        /// /       Crear un nuevo usuario en la base de datos
        /// </summary>k;lj
        /// <param name="usuario"></param>
        /// <returns> </returns>
        /// <exception cref="ArgumentNullException"></exception>
        
        public Task Crear_Usuario(Dominio.Entidades.Usuario usuario)
        {
            //Validar si el usuario no es nulo 
            if (usuario == null)
            {throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo"); }

            // Insertar usuario en la base de datos
            _context.Usuarios.Add(usuario);
            return _context.SaveChangesAsync();

        }

        /// <summary>
        ///     / Modificar los datos de un usuario existente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="correo"></param>
        /// <param name="id_Usuario"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        
        public async Task Modificar_datos_Usuario(string nombre, string apellido, string correo, Guid id_Usuario)
        {
            var usuario = await _context.Usuarios.FindAsync(new Dominio.Objetos_De_Valor.Id_Usuario_Vo(id_Usuario));
            if (usuario == null)
            { throw new ArgumentException("El usuario no existe"); }

            // Validacion para cada valor que si es nulo no haga la modificacion
            Nombre_Usuario_Vo? nuevoNombre = nombre != null ? new Nombre_Usuario_Vo(nombre) : usuario.Nombre_Usuario;
            Apellido_Vo? nuevoApellido = apellido != null ? new Apellido_Vo(apellido) : usuario.Apellido;
            Correo_Vo? nuevoCorreo = correo != null ? new Correo_Vo(correo) : usuario.Correo;

            usuario.ModificarDatos(nuevoNombre, nuevoApellido, nuevoCorreo);

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// /       Registrar una accion en el historial de actividades
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Descripcion"></param>
        /// <param name="Fecha_Hora"></param>
        /// <param name="Id_Usuario"></param>
        /// <returns></returns>

        public async Task Registrar_En_Historial(Guid Id, string Descripcion, DateTime Fecha_Hora, Guid Id_Usuario)
        {
            var historia = new Registrar_Accion_Evento(Id, Descripcion, Fecha_Hora, Id_Usuario);
            _context.Historial_Actividad.Add(historia);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// /        Actualizar la foto de perfil de un usuario
        /// </summary>
        /// <param name="Id_Usuario"></param>
        /// <param name="Imagen_URL"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task Actualizar_Foto_Perfil(Guid Id_Usuario, string Imagen_URL)
        {
            // Obtener el usuario de la Db 
            var usuario = await _context.Usuarios.FindAsync(new Id_Usuario_Vo(Id_Usuario));
            if (usuario == null)
            { throw new ArgumentException("El usuario no existe"); }
           
            // Actualizar la foto de perfil
            usuario.ActualizarFotoPerfil(new Imagen_URL_Vo(Imagen_URL));
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        ///     /       Obtener un usuario por su correo
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<Dominio.Entidades.Usuario> Obtener_Usuario_Por_Correo(string correo)
        {var usuario = await _context.Usuarios.FindAsync(new Correo_Vo(correo) ); ; return usuario!; }

        /// <summary>
        ///                 
        /// </summary>
        /// <param name="id_Usuario"></param>
        /// <returns></returns>
        public async Task<Dominio.Entidades.Usuario> Obtener_Usuario_Por_Id(Guid id_Usuario)
        {var usuario = await _context.Usuarios.FindAsync(new Id_Usuario_Vo(id_Usuario)); return usuario!; }


        /// <summary>
        ///     /       Obtener todos los usuarios de la base de datos  
        /// </summary>
        /// <returns></returns>
        public async Task<List<Dominio.Entidades.Usuario>> Obtener_Todos_Los_Usuarios() {return await _context.Usuarios.ToListAsync(); }


        //Get para historial de actividades

      /* public async Task<List<Registar_Historial_Actividad_Dto>> Obtener_Historial_Por_Usuario(Guid id_Usuario)
        {
            return await _context.Historial_Actividad
                .Where(h => h== id_Usuario)
                .ToListAsync();
        }*/

    }
}
