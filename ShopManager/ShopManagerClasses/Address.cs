using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Address
    {
        public Address()
        {
            // everything null
        }
        public Address(long id, string L1, string L2, string city, string state, string zip)
        {
            ID = id;
            LineOne = L1;
            LineTwo = L2;
            City = city;
            State = state;
            Zip = zip;
        }
        public long ID { get; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Address";
            temp += Environment.NewLine + "ID=" + ID.ToString() + Environment.NewLine + "L1=" + LineOne + Environment.NewLine + "L2=" + LineTwo;
            temp += Environment.NewLine + "City=" + City + Environment.NewLine + "State=" +  State + Environment.NewLine + "Zip=" + Zip;

            return temp;
        }
    }
}
