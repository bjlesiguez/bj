using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    class Program
    {   
        // Interface called IQuittable
        interface IQuittable
        {
            void Quit();
        }
        class Employee : IQuittable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Employee(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            // Implementing the Quit method
            public void Quit()
            {
                Console.WriteLine($"{FirstName} {LastName} has quit their job.");
            }
        }
      
        
            static void Main(string[] args)
            {
                // Create an Employee object
                var employee = new Employee("Thomas", "Clark");

                // Using polymorphism to call the Quit method
                IQuittable quittableEmployee = employee;
                quittableEmployee.Quit();
                Console.ReadLine();
              
            }
        }


        
        
        }
    

