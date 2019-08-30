using System;
using System.Globalization;
using System.Text;

namespace ComparadorDeFrases
{
    class StringChecker
    {
        private const int arrSize = 2;
        public static string[] Normalizator(string[] texts)
        {
            string[] normalizedSet = texts;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < arrSize; i++)
            {
                normalizedSet[i] = texts[i].Normalize(NormalizationForm.FormD);
                char[] temp = normalizedSet[i].ToCharArray();
                foreach (char c in temp)
                {
                    if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }
                normalizedSet[i] = stringBuilder.ToString();
                stringBuilder = stringBuilder.Clear();
            }
            return texts;
        }

        public static string[] stringSorting(string[] text)
        {
            int i = 0;
            foreach (string s in text)
            {
                char[] orderedArray = null;
                orderedArray = text[i].ToCharArray();
                Array.Sort(orderedArray);
                text[i] = new string(orderedArray);
                text[i] = text[i].Replace(" ", string.Empty); i++;
            }
            return text;
        }

        public static string[] CharCounter(string[] texts)
        {

            Normalizator(texts);
            return texts;
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
            string[] stringSet = new string[arrSize] { firstString, secondString };
            stringSorting(stringSet);
            CharCounter(stringSet);

            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine(stringSet[i]); i++;
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}