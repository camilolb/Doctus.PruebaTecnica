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
    public class HorasController : ApiController
    {
        // GET: api/Horas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Horas/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                IList<DominioHoras> listaDominioHoras = new List<DominioHoras>();
                
                if (id > 0)
                {
                    listaDominioHoras = new NegocioHoras().ObtenerPorId(id);

                    if (listaDominioHoras != null
                        && listaDominioHoras.Count > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listaDominioHoras));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: api/Horas
        public HttpResponseMessage Post(DominioHoras dominioHoras)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (dominioHoras != null
                    && dominioHoras.Horas > 0)
                {
                    dominioHoras = new NegocioHoras().Guardar(dominioHoras);

                    if (dominioHoras.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioHoras));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // PUT: api/Horas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Horas/5
        public void Delete(int id)
        {
        }
    }
}
