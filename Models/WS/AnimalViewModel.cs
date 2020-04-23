using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtoken.Models.WS
{
    public class AnimalViewModel : SecurityModel
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int Patas { get; set; }
    }
}