using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MVCtoken.Models.WS;
using MVCtoken.Models;

namespace MVCtoken.Controllers
{
    public class FormularioController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [AllowCrossSiteJson]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]


        public Reply Formulario ([FromBody] AccessViewModel model) {

            Reply oR = new Reply();

            try {
                //Hacer la peticion aca
                using (mvcApiEntities1 db = new mvcApiEntities1()) { 
                


                }


            }
            catch(Exception ex)
            {
                oR.result = 1;
                oR.message = "Ocurrio un error " + ex;
            }
            return null;
        }


    }
}
