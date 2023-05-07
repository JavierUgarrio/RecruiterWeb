using System;
using System.Collections.Generic;

namespace RecruiterWeb.Modelos
{
    public partial class Candidatura
    {
        public Candidatura()
        {
            DetallesCandidaturas = new HashSet<DetallesCandidatura>();
        }

        public int IdCandidatura { get; set; }
        public int IdUsuario { get; set; }
        public string Empresa { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<DetallesCandidatura> DetallesCandidaturas { get; set; }
    }
}
