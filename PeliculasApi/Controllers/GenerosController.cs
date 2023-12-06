using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PeliculasApi.entidades;
using PeliculasApi.repositorios;

namespace PeliculasApi.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController
    {
        private readonly IRepositorio _repositorio;
        public GenerosController(IRepositorio repositorio) {

            _repositorio = repositorio;
        }

        [HttpGet] // /api/generos
        [HttpGet("listado")] // /api/generos/listado
        [HttpGet("/listadogeneros")] // /listadogeneros
        public ActionResult<List<Genero>> Get()
        {
            return _repositorio.ObtenerTodosLosGeneros();
        }

        //Id: Se define que tipo de datos se requiere, si no es el tipo de dato correcto la ruta no se encuentra
        [HttpGet("{Id:int}")] //-> Valores por defecto para variables de ruta
        public async Task<ActionResult<Genero>> Get(int Id, [BindRequired] string nombre)
        {
          //  [BindRequired]-> Regla de validación si han sido respetadas y tira un error si no es valido 

           
               
           var genero= await _repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                return new NotFoundResult();
               
            }
   
            return genero;
             
        }


        [HttpPost]
        public ActionResult Post()
        {
            return new NoContentResult();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return new NoContentResult();
        }
    }
}
