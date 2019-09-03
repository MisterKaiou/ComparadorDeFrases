using System;
using System.Globalization;
using System.Text;

namespace ComparadorDeFrases
{
    class StringChecker
    {
        private const int arrSize = 2;
        public static string[] Normalizator(ref string[] texts)
        {
            //string[] normalizedSet = texts;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < arrSize; i++)
            {
                texts[i] = texts[i].Normalize(NormalizationForm.FormD);
                char[] temp = texts[i].ToCharArray();
                foreach (char c in temp)
                {
                    if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }
                texts[i] = stringBuilder.ToString();
                stringBuilder = stringBuilder.Clear();
            }
            return texts;
        }

        public static string[] StringSorting(ref string[] text)
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

        public static string[] GetStrings(ref string[] stringArray)
        {
            bool isFisrt = true;

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (isFisrt)
                {
                    Console.WriteLine("Por favor, digite a primeira string: ");
                    stringArray[i] = Console.ReadLine();
                    stringArray[i] = stringArray[i].ToLower();
                    isFisrt = !isFisrt;
                }
                else
                {
                    Console.WriteLine("\nPor favor, digite a segunda string: ");
                    stringArray[i] = Console.ReadLine();
                    stringArray[i] = stringArray[i].ToLower();
                }
            }

            return stringArray;
        }

        public static void StringCompare(ref string[] stringArray)
        {
            if (stringArray[0].Equals(stringArray[1]))
            {
                Console.WriteLine("\nVocê digitou um anagrama :O");
            }
            else
            {
                Console.WriteLine("\nEssas palavras não são anagramas :/");
            }
        }

        static void Main(string[] args)
        {
            string[] stringArray = new string[arrSize];

            GetStrings(ref stringArray);
            StringSorting(ref stringArray);
            Normalizator(ref stringArray);
            StringCompare(ref stringArray);

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}