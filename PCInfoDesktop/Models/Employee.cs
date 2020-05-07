using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models
{
    public class Employee
    {
        public int ID
        { get; set; }

        public string Name
        { get; set; }

        public string FirstLastName
        { get; set; }

        public string SecondLastName
        { get; set; }

        public Employee(int id, string name, string firstLastName, string secondLastName)
        {
            ID = id;
            Name = name;
            FirstLastName = firstLastName;
            SecondLastName = secondLastName;
        }

    }
}
