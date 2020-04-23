using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCtoken.Models.WS;
using MVCtoken.Models;
using System.Web.Http.Cors;

namespace MVCtoken.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        public Reply HelloWorld()
        {
            Reply oR = new Reply();
            oR.result = 1;
            oR.message = "Hi world !!";

            return oR;

        }

        [HttpPost]
        [AllowAnonymous]
       [AllowCrossSiteJson]
       [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

        public Reply Login([FromBody] AccessViewModel model) {

            Reply oR = new Reply();

            try 
            {

               using (mvcApiEntities1 db = new mvcApiEntities1())
                {
                    var lst = db.Table1.Where(d => d.email == model.email && d.passwordd == model.password && d.idEstatus == 1);
                    if(lst.Count() > 0)
                    {
                        oR.result = 1;
                        oR.data = Guid.NewGuid().ToString();

                        Table1 oUser = lst.First();
                        oUser.token = (string)oR.data;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        oR.message = "Datos Incorrectos";
                    }
                }
            }
            catch(Exception ex) {
                oR.result = 1;
                oR.message = "Ocurrio un Error"+ex;
            }
            return oR;

        }
    }
}
