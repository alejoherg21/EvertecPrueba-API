using Microsoft.AspNetCore.Mvc;
using Domain;
using Core;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonas personas;

        public PersonasController(IPersonas personas)
        {
            this.personas = personas;
        }

        [HttpPost]
        public IActionResult PostPersona(Persona persona)
        {
            try
            {
                Exception respuesta = personas.AgregarPersona(persona);
                if (respuesta != null) return BadRequest(respuesta.InnerException.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

        [HttpGet]
        public IActionResult GetPersonas()
        {
            List<Persona> persona = new List<Persona>();
            try
            {
                persona = personas.ConsultarPersonas();
                if (persona.Count() == 0) return BadRequest("La tabla persona no retorno registros. Es posible que haya habido un error. Consulte log de errores.");
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPersona(int id)
        {
            try
            {
                Exception respuesta = personas.EliminarPersona(id);
                if (respuesta != null) return BadRequest(respuesta.InnerException.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

        [HttpPut]
        public IActionResult ActualizarPersona(Persona persona)
        {
            try
            {
                Exception respuesta = personas.ActualizarPersona(persona);
                if (respuesta != null) return BadRequest(respuesta.InnerException.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

        [HttpPost("loadImage/{id}")]
        public IActionResult ActualizarFoto(int id)
        {
            try
            {
                IFormFile data = Request.Form.Files[0];
                using (var target = new MemoryStream())
                {
                    data.CopyTo(target);
                    Exception respuesta = personas.ActualizarFoto(id, target.ToArray());
                    if (respuesta != null) return BadRequest(respuesta.InnerException.Message);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

        [HttpGet("getImage/{id}")]
        public IActionResult ObtenerFoto(int id)
        {
            try 
            { 
                byte[] bytes = personas.ObtenerFoto(id);
                return File(bytes, "image/png");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
        }

    }
}
