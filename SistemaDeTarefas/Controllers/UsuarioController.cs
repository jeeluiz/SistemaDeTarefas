using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IUsuariosRepository _usuariosRepository;

    public UsuarioController(IUsuariosRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
    {
        List<UsuarioModel> usuarios = await _usuariosRepository.BuscarTodosUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
    {
        UsuarioModel usuarios = await _usuariosRepository.BuscarProId(id);
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
    {
        UsuarioModel usuario = await _usuariosRepository.Adicionar(usuarioModel);
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
    {
        usuarioModel.Id = id;
        UsuarioModel usuario = await _usuariosRepository.Atualizar(usuarioModel, id);
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioModel>> Apagar([FromBody] UsuarioModel usuarioModel, int id)
    {
        usuarioModel.Id = id;
        bool apagado = await _usuariosRepository.Apagar(id);
        return Ok(apagado);
    }
}
