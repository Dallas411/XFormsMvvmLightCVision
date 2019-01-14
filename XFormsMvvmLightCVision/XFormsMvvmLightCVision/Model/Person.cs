using System;
using System.Collections.Generic;
using System.Text;

namespace XFormsMvvmLightCVision.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Information { get; set; }

        public Person()
        {
        }

        public Person(string name, string surname, List<string> information)
        {
            Name = name;
            Surname = surname;
            Information = information;
        }
    }
}
