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

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Car";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "Make=" + Make;
            temp += Environment.NewLine + "Model=" + Model;
            temp += Environment.NewLine + "Year=" + Year;
            temp += Environment.NewLine + "Vin=" + Vin;
            temp += Environment.NewLine + "State=" + State;
            temp += Environment.NewLine + "Plate=" + Plate;
            temp += Environment.NewLine + "Owner=" + Owner;
            temp += Environment.NewLine + "ProdDate=" + ProdDate;
            return temp;
        }
    }
}
