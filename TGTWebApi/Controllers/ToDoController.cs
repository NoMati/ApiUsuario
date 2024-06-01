using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TGTWebApi.Interfaces;
using TGTWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGTWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public ToDoController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tareas = await _tareaService.GetAllTareasAsync();

                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las tareas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
