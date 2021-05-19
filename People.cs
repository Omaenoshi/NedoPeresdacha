using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NedoExam
{
    class People
    {
        public string Name { get; private set; }

        public int Salary { get; private set; }

        public bool IsBoss { get; private set; }

        public People(string name, int salary, bool isBoss)
        {
            Name = name;
            Salary = salary;
            IsBoss = isBoss;
        }
    }
}
