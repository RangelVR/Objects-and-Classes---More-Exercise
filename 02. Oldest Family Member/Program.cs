﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class Family
        {
            public List<Person> FamilyList { get; set; } = new List<Person>();

            public void AddFamilyMember(string[] person)
            {
                Person newMember = new Person(person[0], int.Parse(person[1]));

                FamilyList.Add(new Person(person[0], int.Parse(person[1])));
            }

            public Person GetOldestPerson()
            {
                return FamilyList.OrderByDescending(x => x.Age).First();
            }
           
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                family.AddFamilyMember(Console.ReadLine().Split());
            }

            Person oldest = family.GetOldestPerson();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
