using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Customer
    {
        public long Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Nullable<long> SpouseID { get; set; }
        public string CompanyName { get; set; }
       
        public Customer(long id, string fname, string lname, long? spouseid, string companyname)
        {
            Id = id;
            FName = fname;
            LName = lname;
            SpouseID = spouseid;
            CompanyName = companyname;
        }
        public Customer()
        {
            Id = -1;
        }
        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Customer";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "FName=" + FName;
            temp += Environment.NewLine + "LName=" + LName;
            temp += Environment.NewLine + "SpouseID=" + SpouseID;
            temp += Environment.NewLine + "CompanyName=" + CompanyName;

            return temp;
        }
    }
}
