using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NedoExam
{
    class Program
    {
        public static List<string> DepartmentsName { get; set; }

        public static List<Department> Departments { get; set; }

        static void Main(string[] args)
        {
            var peopleList = File.ReadAllLines(@"../../../PeoplesList.txt");
            DepartmentsName = new List<string>();
            Departments = new List<Department>();
            CreateDepartments(peopleList);
            FillUpDepartments(peopleList);
            for (var i = 0; i < Departments.Count; i++)
            {
                Console.WriteLine(Departments[i].Name + "\t" + Departments[i].GetAverageSalary());
            }
            Console.WriteLine(Departments.Select(x => x.GetMaxBossSalary()).Max());

        }

        static void CreateDepartments(string[] peopleList)
        {
            for (var i = 0; i < peopleList.Length; i++)
            {
                var peopleInfo = peopleList[i].Split(';');
                if (!DepartmentsName.Contains(peopleInfo[1]))
                {
                    Departments.Add(new Department(peopleInfo[1]));
                    DepartmentsName.Add(peopleInfo[1]);
                }
            }    
        }

        static void FillUpDepartments(string[] peopleList)
        {
            for (var i = 0; i < Departments.Count; i++)
            {
                for (var j = 0; j < peopleList.Length; j++)
                {
                    var peopleInfo = peopleList[j].Split(';');
                    if ( Departments[i].Name == peopleInfo[1])
                    {
                        if (peopleInfo.Length == 3)
                            Departments[i].AddPeople(new People(peopleInfo[0], Int32.Parse(peopleInfo[2]), false));
                        else
                            Departments[i].AddPeople(new People(peopleInfo[0], Int32.Parse(peopleInfo[2]), bool.Parse(peopleInfo[3])));
                    }
                        
                }
            }
        }

    }
}
