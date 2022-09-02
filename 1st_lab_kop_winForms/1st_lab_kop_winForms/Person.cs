using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_lab_kop_winForms
{
    public class Person
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return Surname + " " + FirstName + " " + LastName;
        }
    }
}
