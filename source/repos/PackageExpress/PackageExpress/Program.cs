using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Prompt user for package weight
            Console.Write("Please enter the package weight: ");
            double weight = double.Parse(Console.ReadLine());

            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return;
            }

            // Prompt user for package dimensions
            Console.Write("Please enter the package width: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Please enter the package height: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Please enter the package length: ");
            double length = double.Parse(Console.ReadLine());

            double dimensionsTotal = width + height + length;

            if (dimensionsTotal > 51)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return;
            }

            // Calculate quote
            double product = width * height * length;
            double quote = (product * weight) / 100;

            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
            Console.WriteLine("Thank you!");
            Console.ReadLine();
        }
    }
}
