using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiterWeb.Modelos;
using RecruiterWeb.Modelos.ViewModels;
using System.Text;

namespace RecruiterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Creo este constructror y esta variable para que no este hardcoreada la clavecifrada
        private readonly IConfiguration configuration;
        public UsuariosController(IConfiguration configuration) 
        {
            this.configuration= configuration;
        }

        [HttpGet]
        public IActionResult DameUsuarios()
        {
            Resultado resultado = new Resultado();
            try
            {
                using (RecruiterContext basedatos = new RecruiterContext())
                {
                    var lista = basedatos.Usuarios.ToList();
                    resultado.ObjetoGenerico = lista;
                }
            }catch (Exception ex)
            {
                resultado.Error ="Se produjo un error a la hora de obtener los usuarios " + ex.Message;
                
            }
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult AgregarUsuario(UsuarioViewModel u) 
        {
            Resultado resultado = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                using (RecruiterContext basedatos = new RecruiterContext())
                {
                    Usuario usuario = new Usuario();
                    usuario.Nombre = u.Nombre;
                    usuario.Apellidos = u.Apellidos;
                    usuario.Telefono = u.Telefono;
                    usuario.Email = u.Email;
                    usuario.Password = Encoding.ASCII.GetBytes(util.cifrar(u.Pass, configuration["ClaveCifrado"]));
                    usuario.FechaAlta = DateTime.Now;
                    basedatos.Usuarios.Add(usuario);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado.Error = "Se produjo un error a la hora de hacer el alto al usuario " + ex.Message;
            }
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult EditarUsuario(UsuarioViewModel u)
        {
            Resultado resultado = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                using (RecruiterContext basedatos = new RecruiterContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu=>usu.Email== u.Email);
                    usuario.Nombre = u.Nombre;
                    usuario.Apellidos = u.Apellidos;
                    usuario.Telefono = u.Telefono;
                    usuario.Email = u.Email;
                    basedatos.Entry(usuario).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado.Error = "Se produjo un error a la hora de modificar al usuario " + ex.Message;
            }
            return Ok(resultado);
        }

        [HttpDelete("{Email}")]

        public IActionResult BorrarUsuario(String Email)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (RecruiterContext basedatos = new RecruiterContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu => usu.Email == Email);
                   basedatos.Remove(usuario);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado.Error = "Se produjo un error a la borrar un usuario " + ex.Message;
            }
            return Ok(resultado);
        }


    }
}


//{
//    "Nombre":"Maria",
//    "Apellidos": "Casteleiro",
//    "Telefono" : 1234,
//    "Email":"maria@gmail.com",
//    "Pass" :"PassMaria"

//}