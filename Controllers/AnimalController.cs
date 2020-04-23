using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCtoken.Models.WS;
using MVCtoken.Models;


namespace MVCtoken.Controllers
{
    public class AnimalController : BaseController
    {
        [HttpPost]
        public Reply Get([FromBody]SecurityModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Reply oR = new Reply();
            oR.result = 0;
            if (!Verify(model.token))
            {
                oR.message = "No autorizado";
                return oR;
            }
            try
            {
                using(mvcApiEntities1 db2 = new mvcApiEntities1())
                {
                    List<LsitAnimalsViewModel> lst = (from d in db2.animal
                                                      where d.idState == 1
                                                      select new LsitAnimalsViewModel
                                                      {
                                                          Name = d.name,
                                                          Patas = d.patas
                                                      }).ToList();
                    oR.data = lst;
                    oR.result = 1;
                }
            }
            catch(Exception ex)
            {
                oR.message = "Ocurrio error del servidor"+ex;
            }

            return oR;
        }

      
    }
}
