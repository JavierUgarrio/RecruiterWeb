using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiterWeb.Modelos;

namespace RecruiterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {
        [HttpGet]
        public IActionResult DameProcesos()
        {
            Resultado resultado = new Resultado();
            try
            {
                using (RecruiterContext basedatos = new RecruiterContext())
                {
                    var lista = basedatos.Procesos.ToList();
                    resultado.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = "Se produjo un error a la hora de obtener los procesos " + ex.Message;
            }
            return Ok(resultado);
        }
    }
}
