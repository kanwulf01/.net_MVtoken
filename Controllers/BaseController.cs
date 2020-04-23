using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCtoken.Models;

namespace MVCtoken.Controllers
{
    public class BaseController : ApiController
    {
        public string error = "";
        public bool Verify(string token)
        {
            using (mvcApiEntities1 db1 = new mvcApiEntities1())
            {
                if(db1.Table1.Where(d=>d.token==token && d.idEstatus ==1).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
    }
}
