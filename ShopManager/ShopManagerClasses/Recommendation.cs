using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Recommendation
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long Active { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Recomendation";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "Description=" + Description;
            temp += Environment.NewLine + "Active=" + Active;
            return temp;
        }
    }
}
