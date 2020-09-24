using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class Programmer : Employee
    {
        public Programmer(string firstname, string lastname, DateTime birthdate, double salary) : base(firstname, lastname, birthdate, salary)
        {
        }
    }
}
