using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class House
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int LotSize { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String PostalCode { get; set; }
    }
}