using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Aplicacion.Comandos;
using Dominio.Puertos;
using Infraestructura.Persistencia.Repositorios;
using MassTransit;
using Microsoft.EntityFrameworkCore.Internal;
using Infraestructura.Event_Bus.Consumidores;
using CloudinaryDotNet;
using Infraestructura.Image_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Crear_Usuario_Command).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Modificar_datos_Usuario_Command).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Actualizar_Imagen_Perfil_Command).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Registar_Historial_Actividad_Command).Assembly));


//Configuracion de mass transit  para colas en RabbitMQ

builder.Services.AddMassTransit(x =>
{
//Credenciales de rabbitMq
    var rabbitMq_Host = builder.Configuration["RabbitMQ:Host"];
    var rabbitMq_Usuario = builder.Configuration["RabbitMQ:Username"];
    var rabbitMq_clave = builder.Configuration["RabbitMQ:Password"];


    //Consumidores 
    x.AddConsumer<Registrar_Accion_Consumidor>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitMq_Host, "/", h => 
            { h.Username(rabbitMq_Usuario); h.Password(rabbitMq_clave);});

        cfg.ReceiveEndpoint(("Registrar_Accion"), e =>
           { e.ConfigureConsumer<Registrar_Accion_Consumidor>(context); });

        cfg.ConfigureEndpoints(context);

    });

});

// Configuracion necesaria para CLoudDInary
builder.Services.AddScoped<I_Imagen_Servicio, Servicio_Imagen>();

//Logger
builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

// Repositorios 
builder.Services.AddScoped<IUsuario_Repositorio, Usuario_Repositorio>();

var connectionString = builder.Configuration.GetConnectionString("Conexion_Postgres");
builder.Services.AddDbContext<Db_Context>(options =>
    options.UseNpgsql(connectionString)
);


/////////////////////////////////////////// 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
