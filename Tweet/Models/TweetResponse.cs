using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweet.Models
{
    public class RootObject
    {
        public string id { get; set; }
        public DateTime stamp { get; set; }
        public string text { get; set; }
    }
}