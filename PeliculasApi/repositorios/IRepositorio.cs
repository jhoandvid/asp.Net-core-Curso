using PeliculasApi.entidades;

namespace PeliculasApi.repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObtenerTodosLosGeneros();

        Task<Genero?> ObtenerPorId(int id);
    }
}
