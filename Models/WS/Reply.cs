using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtoken.Models.WS
{
    public class Reply
    {
        public int result
        {
            get; set;
        }
        public object data { get; set; }
        public string message { get; set; }
    }
}