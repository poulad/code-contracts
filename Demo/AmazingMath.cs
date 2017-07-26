// ReSharper disable PossibleLossOfFraction

using System;
using System.Diagnostics.Contracts;

namespace Demo
{
    public class AmazingMath
    {
        public static double Divide(int num, int denom)
        {
            Contract.Requires(denom != 0, "Denominator cannot be zero");
            Contract.EnsuresOnThrow<DivideByZeroException>(denom == 0);

            double result = num / denom;
            return result;
        }

        public static double AbsoluteValue(double number)
        {
            Contract.Ensures(Contract.Result<double>() >= 0, "Result is always 0 or a positive number");

            if (number >= 0)
                return number;

            return -number;
        }

        public static double SquareRoot(double number)
        {
            Contract.Requires(number >= 0, "Number cannot be negative");

            return Math.Sqrt(number);
        }
    }
}
