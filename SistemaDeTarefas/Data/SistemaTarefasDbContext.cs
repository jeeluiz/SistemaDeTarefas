using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data;

public class SistemaTarefasDbContext : DbContext
{
    public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) : base(options)
    {

    }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());
        base.OnModelCreating(modelBuilder);
    }

}
