using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Puertos
{
    public interface IUsuario_Repositorio
    {
        Task Crear_Usuario(Usuario usuario); 
        Task Modificar_datos_Usuario(string? Nombre,string? Apellido, string? Correo, Guid id_usuario);
        ///Task<Usuario> ObtenerPorId(Guid idUsuario);
        Task Registrar_En_Historial(Guid Id, string Descripcion, DateTime Fecha_Hora, Guid Id_Usuario);
        Task Actualizar_Foto_Perfil(Guid Id_Usuario, string Imagen_URL);

        //Gets  para el usuario
        Task<Usuario> Obtener_Usuario_Por_Correo(string correo);
        Task<Usuario> Obtener_Usuario_Por_Id(Guid id_Usuario);

        Task<List<Usuario>> Obtener_Todos_Los_Usuarios();

        //Get para el historial de activida

        // hazme un enum de dos atributos 

        //Task<List<T>> Obtener_Historial_Por_Usuario(Guid id_Usuario);

    }
}
