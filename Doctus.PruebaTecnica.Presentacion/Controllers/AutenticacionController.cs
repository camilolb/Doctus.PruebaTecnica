using Doctus.PruebaTecnica.Negocio.Dominio;
using Doctus.PruebaTecnica.Negocio.Negocio;
using Doctus.PruebaTecnica.Presentacion.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Doctus.PruebaTecnica.Presentacion.Controllers
{
    public class AutenticacionController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]

        [Route("oauth/check")]
        public HttpResponseMessage GetCurrentUser()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            
            try
            {
                var usuario = HttpContext.Current.Request.QueryString["usuario"];
                var password = HttpContext.Current.Request.QueryString["password"];

                DominioUsuario dominioUsuario = new NegocioUsuario().ObtenerUsuario(usuario, password);

                if (dominioUsuario != null
                    && dominioUsuario.Id > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioUsuario));
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, ex);
            }

            return response;
        }
    }
}
