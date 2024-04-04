using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_Parcial
{
    internal class Inscripciones
    {
        int dpi;
        int codigo;
        DateTime inscripcion;

        public int Dpi { get => dpi; set => dpi = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime Inscripcion { get => inscripcion; set => inscripcion = value; }
    }
}
