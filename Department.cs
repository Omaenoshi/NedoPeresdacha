using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NedoExam
{
    class Department
    {
        public string Name { get; private set; }

        public List<People> Peoples { get; private set; }

        public List<People> Bosses { get; private set; }

        public Department(string name)
        {
            Name = name;
            Peoples = new List<People>();
            Bosses = new List<People>();
        }

        public void AddPeople(People people)
        {
            if (people.IsBoss == true)
                Bosses.Add(people);
            else
                Peoples.Add(people);
        }

        public bool CheckBossesCount()
        {
            return Bosses.Count > 2 || Bosses.Count < 1;
        }

        public int GetMaxBossSalary()
        {
            return Bosses.Select(x => x.Salary).Max();
        }

        public double GetAverageSalary()
        {
            var averageSalary = 0.0;

            foreach( var e in Peoples)
                averageSalary += e.Salary;

            return averageSalary /= Peoples.Count;
        }

    }
}
