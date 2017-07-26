using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoMath();

            DemoMyDictionary();

            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        static void DemoMath()
        {
            Console.Write("Enter a number: ");
            double userNumber = double.Parse(Console.ReadLine() ?? "-36");

            double absValue = AmazingMath.AbsoluteValue(userNumber);
            double sqrt = AmazingMath.SquareRoot(absValue);

            Console.WriteLine($"Square root of {absValue} is {sqrt}");
        }

        static void DemoMyDictionary()
        {
            var dict = new AmazingDictionary<int, string>();

            string two = "TWO";
            dict.Set(2, two);

            if (!dict.IsEmpty && dict.Contains(2))
                two = dict.Get(2);

            Console.WriteLine(two);
        }
    }
}
