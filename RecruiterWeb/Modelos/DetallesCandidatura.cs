using System;
using System.Collections.Generic;

namespace RecruiterWeb.Modelos
{
    public partial class DetallesCandidatura
    {
        public int IdDetalleCandidatura { get; set; }
        public int IdCandidaturas { get; set; }
        public int IdProcesos { get; set; }

        public virtual Candidatura IdCandidaturasNavigation { get; set; } = null!;
        public virtual Proceso IdProcesosNavigation { get; set; } = null!;
    }
}
