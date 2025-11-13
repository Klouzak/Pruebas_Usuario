using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Eventos;
using Dominio.Entidades;
using Dominio.Objetos_De_Valor;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions<Db_Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Registrar_Accion_Evento> Historial_Actividad { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>()
                    .ToTable("Usuario")
                    .HasKey(u => u.Id_Usuario);

                // Configurar conversiones para cada  de valor

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Id_Usuario)
                    .HasConversion(
                        id => id.valor_Id_Usuario, value => new Id_Usuario_Vo(value)).HasColumnName("Id_Usuario");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Nombre_Usuario)
                    .HasConversion(
                        nombre => nombre.valor_Nombre_Usuario, value => new Nombre_Usuario_Vo(value)).HasColumnName("Nombre_Usuario");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Apellido)
                    .HasConversion(
                        apellido => apellido.valor_Apellido, value => new Apellido_Vo(value)).HasColumnName("Apellido");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Correo)
                    .HasConversion(
                        correo => correo.valor_Correo, value => new Correo_Vo(value)).HasColumnName("Correo");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Clave)
                    .HasConversion(
                        clave => clave.valor_Clave, value => new Clave_Vo(value)).HasColumnName("Clave");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Rol)
                    .HasConversion(
                        rol => rol.valor_Rol, value => new Rol_Vo(value)).HasColumnName("Rol");

                modelBuilder.Entity<Usuario>()
                    .Property(u => u.Imagen_Perfil)
                    .HasConversion(
                        imagen => imagen != null ? imagen.valor_Imagen_URL: null,
                        value => value != null ? new Imagen_URL_Vo(value) : null).HasColumnName("Imagen_Perfil");


            modelBuilder.Entity<Registrar_Accion_Evento>()
                    // Mapea la clase al nombre de la tabla en la BD
                    .ToTable("historial_actividad")
                    // Establece la clave primaria
                    .HasKey(e => e.id);

        }

        }
    }


