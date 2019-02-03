using Doctus.PruebaTecnica.Negocio.Dominio;
using Doctus.PruebaTecnica.Negocio.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Doctus.PruebaTecnica.Presentacion.Controllers
{
    public class ActividadController : ApiController
    {
        // GET: api/Actividad
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                IList<DominioActividad> listaActividades = new NegocioActividad().ObtenerTodo();

                if (listaActividades != null
                    && listaActividades.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listaActividades));
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // GET: api/Actividad/5
        public void Get(int id)
        {

        }

        // POST: api/Actividad
        public HttpResponseMessage Post(DominioActividad dominioActividad)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (dominioActividad != null
                    && !string.IsNullOrEmpty(dominioActividad.Descripcion))
                {
                    dominioActividad = new NegocioActividad().Guardar(dominioActividad);

                    if (dominioActividad.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioActividad));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // PUT: api/Actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividad/5
        public HttpResponseMessage Delete(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                new NegocioActividad().Eliminar(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;

        }
    }
}
