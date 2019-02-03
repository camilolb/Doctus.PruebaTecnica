using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctus.PruebaTecnica.Negocio.Dominio
{
    public class DominioHoras
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int Horas { get; set; }
        
        public int IdActividad { get; set; }
    }
}
