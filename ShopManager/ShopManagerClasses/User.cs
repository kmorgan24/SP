using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public interface User
    {
        long Id { get; set; }
        string Name { get; set; }
        string LoginName { get; set; }
        string Password { get; set; }
        long LoggedIn { get; set; }
        long Active { get; set; }
    }
}
