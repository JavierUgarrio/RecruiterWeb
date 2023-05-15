using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiterWeb.Modelos;
using RecruiterWeb.Modelos.ViewModels;
using RecruiterWeb.Servicios;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecruiterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        // Creo este constructror y esta variable para que no este hardcoreada la clavecifrada
        private readonly IConfiguration configuration;
        private IUsuarioAPI usuarioAPIServicio;
        public UsuarioApiController(IConfiguration configuration, IUsuarioAPI usuarioAPIServicio)
        {
            this.configuration = configuration;
            this.usuarioAPIServicio = usuarioAPIServicio;
        }
        //Prueba de alta en el login
        //[HttpPost("Alta")]
        //public IActionResult AltaUsuario(AuthApi usuarioAPI) 
        //{
        //    Resultado resultado = new Resultado();
        //    try
        //    {
        //        byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //        Util util = new Util(keyBbyte);
        //        using(RecruiterContext basedatos = new RecruiterContext()) { 
        //        UsuariosApi api = new UsuariosApi();
        //        api.Email = usuarioAPI.email;
        //        api.Password =Encoding.ASCII.GetBytes(util.cifrar(usuarioAPI.password, configuration["ClaveCifrado"]));
        //        api.FechaAlta=DateTime.Now;
        //            basedatos.UsuariosApis.Add(api);
        //            basedatos.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        resultado.Error = "Se produjo un error al dar de alta al USUARIOAPI" + ex.Message;
        //    }
        //    return Ok(resultado);
        //}

        [HttpPost]
        public IActionResult DevolverUsuario(AuthApi auth)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado.ObjetoGenerico = usuarioAPIServicio.Autenticacion(auth);

            }
            catch (Exception ex)
            {
                resultado.Error = "Se produjo un error al obtener el usuario y contraseña de api" + ex.Message;
            }
            return Ok(resultado);
        }
    }
}


//{
//"email": "gil@gmail.com",
//"password" : "12345"
//}
