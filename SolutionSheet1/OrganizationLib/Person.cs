using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public abstract class Person
    {
        string firstname;
        string lastname;

        DateTime birthdate;

        private GenderType gender;

        public GenderType Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Fullname { get { return firstname + " " + lastname; } }

        public int Age { get { return DateTime.Now.Year - birthdate.Year; } }

        public virtual string Print()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("-------------------------");
            st.AppendLine($"Nome Completo: {Fullname}");
            st.AppendLine($"Idade {Age}");
            st.AppendLine("-------------------------");

            return st.ToString();
        }

        protected Person()
        {
            firstname = "";
            lastname = "";
            birthdate = new DateTime(1999, 1, 1);
        }

        protected Person(string firstname, string lastname, DateTime birthdate)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
        }
    }
}
