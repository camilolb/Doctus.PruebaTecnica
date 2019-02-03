using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctus.PruebaTecnica.Negocio.Dominio
{
    public class DominioActividad
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime Creado { get; set; }

        public DateTime? Modificado { get; set; }

        


    }
}
