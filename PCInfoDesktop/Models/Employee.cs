using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models
{
    public class Employee
    {
        private int id;
        private string name;
        private string firstLastName;
        private string secondLastName;


        public Employee(int id, string name, string firstLastName, string secondLastName)
        {
            this.id = id;
            this.name = name;
            this.firstLastName = firstLastName;
            this.secondLastName = secondLastName;
        }

    }
}
