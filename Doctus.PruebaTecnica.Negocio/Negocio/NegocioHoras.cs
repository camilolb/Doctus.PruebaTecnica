using Doctus.PruebaTecnica.Data;
using Doctus.PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctus.PruebaTecnica.Negocio.Negocio
{
    public class NegocioHoras
    {

        public IList<DominioHoras> ObtenerPorId(int id)
        {
            IList<DominioHoras> listaDominioHoras = null;

            if (id > 0)
            {
                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {

                    var lista = dbContext.Horas.Where(x => x.IdActividad == id).ToList();

                    if (lista != null
                        && lista.Count > 0)
                    {
                        listaDominioHoras = new List<DominioHoras>();

                        foreach (var item in lista)
                        {
                            DominioHoras dominioHoras = new DominioHoras();

                            dominioHoras = ObtenerDominioHoras(item);
                            listaDominioHoras.Add(dominioHoras);
                        }

                    }
                }
            }

            return listaDominioHoras;
        }

        public DominioHoras Guardar(DominioHoras dominioHoras)
        {

            if (dominioHoras != null
                && dominioHoras.IdActividad > 0
                && dominioHoras.Horas > 0)
            {
                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {
                    var resultado = dbContext.Horas.Add(new Horas()
                    {
                         Fecha = dominioHoras.Fecha
                         , Hora = dominioHoras.Horas
                         , IdActividad = dominioHoras.IdActividad
                    });


                    if (dbContext.SaveChanges() > 0)
                    {
                        dominioHoras.Id = resultado.Id;
                    }
                }
            }

            return dominioHoras;
        }

        public DominioHoras ObtenerDominioHoras(Horas entity)
        {
            DominioHoras dominioHoras = null;

            if (entity != null)
            {
                dominioHoras = new DominioHoras()
                {
                    Id = entity.Id
                    , Fecha = entity.Fecha
                    , Horas = entity.Hora
                    , IdActividad = entity.IdActividad
                };
            }

            return dominioHoras;
        }


    }
}
