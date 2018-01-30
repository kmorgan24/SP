using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Part
    {
        public long Id { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public long InStock { get; set; }
        public string Supplier { get; set; }
        public long WorkOrderID { get; set; }
    }
}
