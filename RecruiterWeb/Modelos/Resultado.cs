namespace RecruiterWeb.Modelos
{
    //Clase generica que devuelve el estado de las peticiones
    public class Resultado
    {
        public object ObjetoGenerico { get; set; }
        public string Texto { get; set; }
        public string Error { get; set; }
    }
}
