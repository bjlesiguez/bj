using System;

namespace MathOperationsApp
{
    class MathOperations
    {
        public void PerformMathOperation(int firstNumber, int secondNumber)
        {
            // Math operation
            int result = firstNumber * 3;

            // method do a math operation on the first integer and display the second integer to the screen
            Console.WriteLine($"Result of the math operation: {result}");
            Console.WriteLine($"Second integer: {secondNumber}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of MathOperations class
            MathOperations mathOps = new MathOperations();

            // Call the method in the class, passing in two numbers
            mathOps.PerformMathOperation(100, 200);

            // Call the method in the class, specifying the parameters by name
            mathOps.PerformMathOperation(firstNumber: 20, secondNumber: 10); // Example values

            // Keep the console window open
            Console.ReadLine();
        }
    }
}
