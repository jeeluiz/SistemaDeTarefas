using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

builder.Services.AddScoped<IUsuariosRepository, UsuarioRespository>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
