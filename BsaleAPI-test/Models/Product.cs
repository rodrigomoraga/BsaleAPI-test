using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsaleAPI_test.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url_Image { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Category { get; set; }
    }
}
