using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces;

public interface IUsuariosRepository
{
    Task<List<UsuarioModel>> BuscarTodosUsuarios();
    Task<UsuarioModel> BuscarProId(int id);
    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
    Task<bool> Apagar(int id);

}
