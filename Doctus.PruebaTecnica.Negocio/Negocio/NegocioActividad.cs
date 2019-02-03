using Doctus.PruebaTecnica.Data;
using Doctus.PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctus.PruebaTecnica.Negocio.Negocio
{
    public class NegocioActividad
    {
        public IList<DominioActividad> ObtenerTodo()
        {
            IList<DominioActividad> listaDominioActividad = null;

            using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
            {
                var lista = dbContext.Actividad.OrderByDescending(x => x.Estado).ToList();

                if (lista != null
                    && lista.Count > 0)
                {
                    listaDominioActividad = new List<DominioActividad>();

                    foreach (var item in lista)
                    {
                        if (item.Estado)
                        {
                            DominioActividad dominioActividad = ObtenerDominioActividad(item);
                            listaDominioActividad.Add(dominioActividad);
                        }
                    }
                }
            }
            return listaDominioActividad;
        }

        
        public DominioActividad Guardar(DominioActividad dominioActividad)
        {

            if (dominioActividad != null
               && !string.IsNullOrEmpty(dominioActividad.Descripcion))
            {
                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {
                    var resultado = dbContext.Actividad.Add(new Actividad()
                    {
                        Descripcion = dominioActividad.Descripcion
                        , Estado = true
                        , Creado = DateTime.Now
                    });


                    if (dbContext.SaveChanges() > 0)
                    {
                        dominioActividad.Id = resultado.Id;
                    }
                }
            }

            return dominioActividad;
        }

        public void Eliminar(int id)
        {
            if (id > 0)
            {
                using (var dbContext = new PruebaTecnicaEntities())
                {
                    var actividad = dbContext.Actividad.Where(x => x.Id == id).FirstOrDefault();

                    if (actividad != null
                        && actividad.Id > 0)
                    {
                        actividad.Estado = false;
                        //actividad.Modificado = DateTime.Now();

                        dbContext.Entry(actividad).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();  
                    }
                }
            }
        }

        public DominioActividad ObtenerDominioActividad(Actividad entity)
        {
            DominioActividad dominioActividad = null;

            if (entity != null)
            {
                dominioActividad = new DominioActividad()
                {
                    Id = entity.Id
                    , Descripcion = entity.Descripcion
                    , Estado = entity.Estado
                    , Creado = entity.Creado
                    ,Modificado = entity.Modificado
                };
            }

            return dominioActividad;
        }
    }
}
