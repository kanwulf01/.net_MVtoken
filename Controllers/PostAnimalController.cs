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
    public class PostAnimalController : BaseController
    {
        [HttpPost]
        public Reply Add([FromBody]AnimalViewModel model)
        {
            Reply oR = new Reply();
            oR.result = 0;

            if (!Verify(model.token))
            {
                oR.message = "No autorizado";
                return oR;
            }
            //vALIDA

            if (!Validate(model))
            {
                oR.message = error;
                return oR;
            }

            try
            {
                using (mvcApiEntities1 db3 = new mvcApiEntities1())
                {
                    animal oAnimal = new animal();
                    oAnimal.idState = 1;
                    oAnimal.name = model.Name;
                    oAnimal.patas = model.Patas;

                    db3.animal.Add(oAnimal);
                    db3.SaveChanges();

                    List<LsitAnimalsViewModel> lst = (from d in db3.animal
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
            catch (Exception ex)
            {
                oR.message = "Ocurrio error del servidor" + ex;

            }
            return oR;
        }

        #region HELPERS

        private bool Validate(AnimalViewModel model)
        {
            if(model.Name == "")
            {
                error = "El nombre es obligatorio";
            }
            return true;
        }


        #endregion
    }
}
