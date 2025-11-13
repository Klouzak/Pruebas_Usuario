using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Objetos_De_Valor;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public Id_Usuario_Vo Id_Usuario { get; private set; }
        public Nombre_Usuario_Vo Nombre_Usuario { get; private set; }
        public Apellido_Vo Apellido { get; private set; }
        public Correo_Vo Correo { get; private set; }
        public Clave_Vo Clave { get; private set; }
        public Rol_Vo Rol { get; private set; }

        public Imagen_URL_Vo? Imagen_Perfil { get; private set; }

        // Constructor entidad de Usuario
        public Usuario(Id_Usuario_Vo id_Usuario, Nombre_Usuario_Vo nombre_Usuario, Apellido_Vo apellido,
            Correo_Vo correo, Clave_Vo clave, Rol_Vo rol, Imagen_URL_Vo? imagen_Perfil)
        {
            Id_Usuario = id_Usuario;
            Nombre_Usuario = nombre_Usuario;
            Apellido = apellido;
            Correo = correo;
            Clave = clave;
            Rol = rol;
            Imagen_Perfil = imagen_Perfil;
        }

        // Constructor vacio para entity framewor
        public Usuario()
        {
        }

        // Modificar datos del usuario para el modificar 
        public void ModificarDatos(Nombre_Usuario_Vo? nuevoNombre, Apellido_Vo? nuevoApellido, Correo_Vo? nuevoCorreo)
        {Nombre_Usuario = nuevoNombre; Apellido = nuevoApellido; Correo = nuevoCorreo; }

        // Actualizar la foto de perfil del usuario
        public void ActualizarFotoPerfil(Imagen_URL_Vo nuevaImagenURL)
        {
            Imagen_Perfil = nuevaImagenURL;
        }

        public void Actualizar_Nombre(Nombre_Usuario_Vo nuevoNombre) {Nombre_Usuario = nuevoNombre; }

        public void Actualizar_Apellido(Apellido_Vo nuevoApellido) {Apellido = nuevoApellido; }

        public void Actualizar_Correo(Correo_Vo nuevoCorreo) {Correo = nuevoCorreo;}

        public void Actualizar_Clave(Clave_Vo nuevaClave) { Clave = nuevaClave; }

    }

}
