using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private readonly BodegaDAL _dal;

        public BodegaController(BodegaDAL dal)
        {
            _dal = dal;
        }



        // GET: api/<BodegaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BodegaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearBodegaDTO crearBodegaDTO)
        {
            var bodega = new Bodega
            {
                Nombre = crearBodegaDTO.Nombre,
                Descripcion = crearBodegaDTO.Descripcion
            };

            int result = await _dal.CrearBodega(bodega);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // PUT api/<BodegaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BodegaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
