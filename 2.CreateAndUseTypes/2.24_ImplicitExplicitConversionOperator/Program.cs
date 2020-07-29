using System;

namespace _2._24_ImplicitExplicitConversionOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;

            Console.WriteLine("Decimal: {0}", amount);
            Console.WriteLine("Int: {0}", truncatedAmount);
            Console.ReadLine();
        }
    }

    class Money
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
}
