using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class Custumer : Person
    {
        public Custumer(string firstname, string lastname, DateTime birthdate, string address) : base(firstname, lastname, birthdate)
        {
            Address = address;
        }

        public string Address { get; set; }

        public override string Print()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("-------------------------");
            st.AppendLine($"Nome Completo: {Fullname}");
            st.AppendLine($"Idade: {Age}");
            st.AppendLine($"Morada: {Address}");
            st.AppendLine("-------------------------");

            return base.Print();
        }
    }
}
