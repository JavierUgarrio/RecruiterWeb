using System;
using System.Collections.Generic;

namespace RecruiterWeb.Modelos
{
    public partial class Proceso
    {
        public Proceso()
        {
            DetallesCandidaturas = new HashSet<DetallesCandidatura>();
        }

        public int IdProceso { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Cliente { get; set; } = null!;

        public virtual ICollection<DetallesCandidatura> DetallesCandidaturas { get; set; }
    }
}
