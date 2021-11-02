using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarafonSKills.Model
{
    public partial class Registration
    {
        public string FullName
        {
            get
            {
                string fullname = Runner.User.FirstName + " " + Runner.User.LastName + " - " + Runner.CountryCode;
                return fullname;
            }
        }
    }
}
