using System;
using System.Text;
using System.Globalization;

namespace ComparadorDeFrases
{
    class StringChecker
    {
        public static string Normalizator(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string stringSorting(string text)
        {
            char[] orderedArray = firstString.ToCharArray();
            Array.Sort(orderedArray);
            firstString = new string(orderedArray);
            firstString = firstString.Replace(" ", string.Empty);

        }

        public static void CharCounter(string firstString, string secondString)
        {

            firstString = Normalizator(firstString);

        }

        public static void GetStrings(out string fs, out string ss)
        {
            Console.WriteLine("Por favor, digite a primeira string: ");
            fs = Console.ReadLine();
            fs = fs.ToLower();

            Console.WriteLine("\nPor favor, digite a segunda string: ");
            ss = Console.ReadLine();
            ss = ss.ToLower();
        }


        static void Main(string[] args)
        {
            bool allSame = true;

            GetStrings(out string firstString, out string secondString);

            CharCounter(firstString, secondString);

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}