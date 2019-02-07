using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Person() { }

        public Person(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
