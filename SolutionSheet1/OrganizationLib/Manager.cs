using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class Manager : Employee
    {
        private List<Programmer> _programmers;

        public Programmer this[int index] { get { return this._programmers[index]; } }

        public int NumberOfProgrammers { get { return this._programmers.Count; } }

        public Manager(string firstname, string lastname, DateTime birthdate, double salary) : base(firstname, lastname, birthdate, salary)
        {
            _programmers = new List<Programmer>();
        }

        public void AddProgrammer(Programmer programmer)
        {
            _programmers.Add(programmer);
        }

        public int MyProperty { get; private set; }

        public override string Print()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("*************************************");
            st.AppendLine($"- Nome Completo: {Fullname}");
            st.AppendLine($"- Idade: {Age}");
            st.AppendLine($"- Salario: {Salary}");
            st.AppendLine("*************************************");
            st.AppendLine($"\n***** Lista de Programadores *****");
            st.AppendLine("*************************************");
            foreach (var programer in _programmers)
            {
                st.AppendLine(programer.Print());
            }
            st.AppendLine("*************************************");
            st.AppendLine($"*Total de programadores: {NumberOfProgrammers}");
            st.AppendLine("*************************************");

            return base.Print();
        }
    }
}
