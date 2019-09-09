using System;
using System.Globalization;
using System.Text;

namespace ComparadorDeFrases
{
    class StringChecker
    {
        private const int arrSize = 2;          //Defines the maximum amount of sentences to compare.

        //Responsible for the removal of diacritcs on each sentence.
        public static string[] Normalizator(ref string[] texts)
        {
            StringBuilder stringBuilder = new StringBuilder();                          //Initialize StringBuilder

            //In each sentence...
            for (int i = 0; i < arrSize; i++)
            {
                texts[i] = texts[i].Normalize(NormalizationForm.FormD);                 //Replaces the current text on the array for the same version but normalized(diacritcs separated).
                char[] temp = texts[i].ToCharArray();                                   //Creates a temporary char array with each character of the now normalized text.

                //For each character on that sentence...
                foreach (char c in temp)
                {
                    if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)   //If it's not a diacritc...
                    {
                        stringBuilder.Append(c);                                        //then append character on a new string.
                    }
                }

                texts[i] = stringBuilder.ToString();        //Replaces old text for the new one.
                stringBuilder = stringBuilder.Clear();      //Clear StringBuilder.
            }
            return texts;           //Returns both senteces but without diacritcs.
        }

        //Responsible for sorting the string, and cleaning whitespaces.
        public static string[] StringSorting(ref string[] text)
        {
            int i = 0;

            foreach (string s in text)                                  //For each string in text array...
            {
                char[] orderedArray = null;                             //Creates a temporary char array.
                orderedArray = text[i].ToCharArray();                   //Ordered array receives the current string in text but as a char array.
                Array.Sort(orderedArray);                               //Ordered array get sorted alphabetically.
                text[i] = new string(orderedArray);                     //Old text now receives a new string formed from the orderedArray.
                text[i] = text[i].Replace(" ", string.Empty); i++;      //Replaces all space on that string for an empty character, removing it completely; Then increments.
            }
            return text;            //Returns both sentences, but now sorted and without spaces.
        }

        //Responsible for receiving both strings from user.
        public static string[] GetStrings(ref string[] stringArray)
        {
            bool isFisrt = true;                //Just for good looks.

            for (int i = 0; i < stringArray.Length; i++)
            {
                //If is the first prompt...
                if (isFisrt)
                {
                    Console.WriteLine("Por favor, digite a primeira frase: ");
                    stringArray[i] = Console.ReadLine();            //Receives first string from user...
                    stringArray[i] = stringArray[i].ToLower();      //Set it to lowercase character...
                    isFisrt = !isFisrt;                             //Inverts boolean.
                }
                else
                {
                    Console.WriteLine("\nPor favor, digite a segunda frase: ");
                    stringArray[i] = Console.ReadLine();            //Receives second string from user...
                    stringArray[i] = stringArray[i].ToLower();      //Set it to lowercase character...
                }
            }

            return stringArray;         //Returns an array with both sentences given from user.
        }

        //Responsible for comparing both string.
        public static void StringCompare(ref string[] stringArray)
        {
            //If first entry in array equals to second one...
            if (stringArray[0].Equals(stringArray[1]))
            {
                Console.WriteLine("\nVocê digitou um anagrama :O");         //Warns the user.
            }
            else        //If not...
            {
                Console.WriteLine("\nEssas palavras não são anagramas :/"); //Warns the user.
            }
        }

        //Responsible for repeat the code if user wants to.
        public static bool MayWeContinue(ref bool mantain)
        {
            char choice;
            bool valid = true;
            do
            {
                Console.WriteLine("\n\nGostaria de Continuar? (S/N)");  //Asks the user if it wants to continue...
                choice = Console.ReadKey().KeyChar;                     //Get the answer from user...
                char.ToLower(choice);                                   //Set it to lowercase...
                
                //If user's choice is 's' or 'n'...
                if (choice.Equals('s') || choice.Equals('n'))
                {   
                    //Then, if his choice is 's'...
                    if (choice.Equals('s'))
                    {
                        //Sets received boolean as true.
                        mantain = true;
                    }
                    else
                    {   
                        //Sets received boolean as false.
                        mantain = false;
                    }
                }
                //If user's choice is not 's' nor 'n'...
                else
                {
                    //Warns user.
                    Console.WriteLine("\nPor favor, digite uma escolha válida...");
                    valid = false;      //Boolean for valid choice is set to false.
                }

            } while (valid == false);   //Repeats this code for as long as his choice is invalid

            return mantain;         //Returns boolean.
        }

        //Greeting text.
        public static void GreetScreen()
        {
            Console.WriteLine("Bem vindo ao identificador de anagramas 2000!!\n");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            string[] stringArray = new string[arrSize];     //Initialize array that will store both sentences.
            bool mantain = false;                           //Boolean responsible for keeping the code running if the user wishes to.

            GreetScreen();      //Runs greeting text.

            //Runs the code
            do
            {
                Console.Clear();
                GetStrings(ref stringArray);            //Receives two string from user...
                Normalizator(ref stringArray);          //Removes diacritcs from both strings...
                StringSorting(ref stringArray);         //Sort both strings alphabetically...
                StringCompare(ref stringArray);         //Compare both string, warns the user if either equal or not...
                MayWeContinue(ref mantain);             //Asks the user if the program should continuue to run.

            } while (mantain);      //Keep the program running, if true.

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}