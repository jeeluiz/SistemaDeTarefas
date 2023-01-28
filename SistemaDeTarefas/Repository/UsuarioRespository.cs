using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Repository;

public class UsuarioRespository : IUsuariosRepository
{
    private readonly SistemaTarefasDbContext _dbContext;

    public UsuarioRespository(SistemaTarefasDbContext sistemaTarefasDbContext, SistemaTarefasDbContext dbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<UsuarioModel> BuscarProId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await BuscarProId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuario Nao Encontrado");
        }
        usuarioPorId.Nome = usuario.Nome;
        usuarioPorId.Email = usuario.Email;

        _dbContext.Usuarios.Update(usuarioPorId);
        _dbContext.SaveChanges();

        return usuarioPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        UsuarioModel usuarioPorId = await BuscarProId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuario Nao Encontrado");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return true;

    }



}
