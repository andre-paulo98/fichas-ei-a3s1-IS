using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public abstract class Employee : Person
    {

        private double _salary;

        public virtual double Salary { get { return _salary; } }

        protected Employee(string firstname, string lastname, DateTime birthdate, double salary ) : base(firstname, lastname, birthdate)
        {
            _salary = salary;
        }

        public override string Print()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("-------------------------");
            st.AppendLine($"Nome Completo: {Fullname}");
            st.AppendLine($"Idade: {Age}");
            st.AppendLine($"Salario: {Salary}");
            st.AppendLine("-------------------------");

            return base.Print();
        }
    }
}
