using RecruiterWeb.Modelos.ViewModels;

namespace RecruiterWeb.Servicios
{
    //UTILIZO LOS SERVICIOS PARA COMUNICAR EL CONTROLADOR Y LA BASE DE DATOS (PARA HACER LA INYECCION DE DEPENDECIAS)
    public interface IUsuarioAPI
    {
        public UsuarioApiViewModel Autenticacion(AuthApi authAPI);
        
    }
}
