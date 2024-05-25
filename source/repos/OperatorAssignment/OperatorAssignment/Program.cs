using System;

namespace EmployeeComparisonApp
{
    class Employee
    {
        // Employee class with Id, FirstName and LastName properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the equality operator to compare Employee objects by their Id property
        public static bool operator ==(Employee emp101, Employee emp102)
        {
            if (ReferenceEquals(emp101, emp102))
                return true;

            if (emp101 is null || emp102 is null)
                return false;

            return emp101.Id == emp102.Id;
        }

        public static bool operator !=(Employee emp101, Employee emp102)
        {
            return !(emp101 == emp102);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating two Employee objects
            Employee employee101 = new Employee { Id = 101, FirstName = "Tim", LastName = "Yap" };
            Employee employee102 = new Employee { Id = 102, FirstName = "Christy", LastName = "Fermin" };

            // Comparing the two Employee objects using the overloaded operators
            bool areEqual = employee101 == employee102;

            Console.WriteLine($"Are the employees equal? {areEqual}");
            Console.ReadLine();
        }
    }
}
