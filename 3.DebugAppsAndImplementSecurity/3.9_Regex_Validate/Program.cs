﻿using System;
using System.Text.RegularExpressions;

namespace _3._9_Regex_Validate
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipCode = "1234AB";
            Console.WriteLine(ValidateZipCode(zipCode));
            Console.WriteLine("RegEx: " + ValidateZipCodeRegEx(zipCode));
            Console.ReadLine();
        }

        static bool ValidateZipCode(string zipCode)
        {
            //valid zipcodes 1234AB, 1234 AB, 1001 AB

            if (zipCode.Length < 6) return false;

            string numberPart = zipCode.Substring(0, 4);
            int number;
            if (!int.TryParse(numberPart, out number)) return false;

            string characterPart = zipCode.Substring(4);

            if (numberPart.StartsWith("0")) return false;
            if (characterPart.Trim().Length < 2) return false;
            if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
                return false;

            return true;
        }

        static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode,
                @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }
    }
}
