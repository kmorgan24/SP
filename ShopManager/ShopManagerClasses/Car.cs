using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Car
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long Year { get; set; }
        public string Vin { get; set; }
        public string State { get; set; }
        public string Plate { get; set; }
        public long Owner { get; set; }
        public string ProdDate { get; set; }
    }
}
