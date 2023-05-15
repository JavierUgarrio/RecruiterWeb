using Microsoft.AspNetCore.Mvc;
using RecruiterWeb.Modelos;
using RecruiterWeb.Modelos.ViewModels;
using System.Text;

namespace RecruiterWeb.Servicios
{
    public class UsuarioAPIServicio : IUsuarioAPI
    {
        private readonly IConfiguration configuration;
        public UsuarioAPIServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UsuarioApiViewModel Autenticacion(AuthApi authAPI)
        {

            UsuarioApiViewModel res = new UsuarioApiViewModel();
            byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Util util = new Util(keyBbyte);
            using (RecruiterContext basedatos = new RecruiterContext())
            {
                UsuariosApi usuarioAPI = basedatos.UsuariosApis.Single(usuario => usuario.Email == authAPI.email);
                if (usuarioAPI != null & 
                    authAPI.password == util.descifrar(Encoding.ASCII.GetString(usuarioAPI.Password), configuration["ClaveCifrada"]))
                {
                    res.email = usuarioAPI.Email;
                }
                else
                {
                    throw new Exception("Usuario no reconocido");
                }
            }
            return res;

        }
    }
}
