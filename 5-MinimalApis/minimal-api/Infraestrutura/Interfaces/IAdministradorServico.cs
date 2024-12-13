
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    Administrador? BuscaPorId(int id);
   List<Administrador> Todos(int? pagina);
}