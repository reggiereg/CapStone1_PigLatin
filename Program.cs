using System;
using System.Text;

namespace CapStone1_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            //check if user wants to continue entering in phrases
            string option = "y";
            //condition to continue program if user specifies to do so
            while (option == "y")
            {
                //string builder object that holds the translated string
                StringBuilder translatedString = new StringBuilder("");
                //string array to break up the users input into individual words
                string[] usersPhraseBroken;
                //gets the first character of each word in the string array
                char firstChar;
                //stores the results of function GetUserInput to capture the users input
                string usersPhrase = GetUserInput("Welcome to Pig Latin 101!! Enter in your word or phrase:");
                //stores thee result of the function StringBreakUP to capture the word (string) array
                usersPhraseBroken = StringBreakUP(usersPhrase);
                //captures the translated word from the Vowel_Translator and Consonant_Translator functions
                string newPhrase = "";
                //loop through the string array containing the individual words entered by the user
                for (int i = 0; i < usersPhraseBroken.Length; i++)
                {
                    //captures the first character in the string of each word in the string array
                    firstChar = usersPhraseBroken[i][0];
                    //check if the word being evaluated starts with a vowel
                    if (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u' || firstChar == 'A' || firstChar == 'E' || firstChar == 'I' || firstChar == 'O' || firstChar == 'U')
                    {
                        //calls the function to translate words beginning with a vowel
                        newPhrase = Vowel_Translator(usersPhraseBroken[i]);
                        //appends the translated word to the string builder object
                        translatedString.Append(newPhrase + " ");
                    }
                    //calls the function to translate words beginning with a consonant
                    else
                    {
                        //calls the function to translate words beginning with a consonant
                        newPhrase = Consonant_Translator(usersPhraseBroken[i]);
                        //appends the translated word to the string builder object
                        translatedString.Append(newPhrase + " ");
                    }
                }
                Console.Write("Translated phrase: ");
                //writes the translated string to the console
                Console.WriteLine($"{translatedString}", Console.ForegroundColor = ConsoleColor.Green);
                //prompt to continue the program
                Console.WriteLine("Would you like to translate another phrase? (y/n)");
                //capture what the user entered for continuing the program or not 
                option = Console.ReadLine();
                //loop until user specifies y or n to continue or stop the program
                while (option[0] != 'y' && option[0] != 'n')
                {
                    Console.WriteLine("Invalid input.  Would you like to enter another phrase? (y/n)");
                    option = Console.ReadLine();
                }
            }
        }
        //write message and get user input function
        public static string GetUserInput(string message)
        {
            Console.WriteLine($"{message} \n", Console.ForegroundColor = ConsoleColor.Red);
            string input = Console.ReadLine();
            return input;
        }
        //break up the string object and puts each word seperated by a space into a string array
        public static string[] StringBreakUP(string phrase)
        {
            phrase = phrase.ToLower();
            return phrase.Split();
        }
        //translates the words that start with a vowel
        public static string Vowel_Translator(string phrase)
        {
            //stores the phrase that will be returned
            string returnPhrase = "";
            //makes sure no special characters or numbers are in the array.  If so, the original phrase is returned
            if ((!phrase.Contains('1')) && (!phrase.Contains('2')) && (!phrase.Contains('3')) && (!phrase.Contains('4')) && (!phrase.Contains('5')) && (!phrase.Contains('6')) && (!phrase.Contains('7')) && (!phrase.Contains('8')) && (!phrase.Contains('9')) && (!phrase.Contains('0') && (!phrase.Contains('@') && (!phrase.Contains('#')) && (!phrase.Contains('%')) && (!phrase.Contains('&')) && (!phrase.Contains('*')) && (!phrase.Contains('-')) && (!phrase.Contains('_')) && (!phrase.Contains('+')) && (!phrase.Contains('=')))))
            {
                returnPhrase = phrase + "way";
                return returnPhrase;
            }
            else
            {
                return phrase;
            }
        }
        //function that translates the words beginning with a consonant
        public static string Consonant_Translator(string phrase)
        {
            //stores the phrase to be returned
            string returnPhrase = "";
            //index counter of the string suppled.  To be used to capture the index of the first vowel in the word
            int indexV = 0;
            //stores all the consonants while looping through the string
            string constString = "";
            //keeps the remaining string including the first vowel found
            string remainString = "";
            //makes sure string doesn't contain numbers or special chars
            if ((!phrase.Contains("1") && !phrase.Contains("2") && !phrase.Contains("3") && !phrase.Contains("4") && !phrase.Contains("5") && !phrase.Contains("6") && !phrase.Contains("7") && !phrase.Contains("8") && !phrase.Contains("9") && !phrase.Contains("0") && !phrase.Contains("@") && !phrase.Contains("#") && !phrase.Contains("$") && !phrase.Contains("%") && !phrase.Contains("^") && !phrase.Contains("&") && !phrase.Contains("*") && !phrase.Contains("+") && !phrase.Contains("=") && !phrase.Contains("-")))
            {
                //loops through string until vowel found or if no vowels found.  If vowel found, translation happens.  If no vowel found, no translation happens i.e. "why" just translates to why 
                while ((phrase[indexV] != 'A' && phrase[indexV] != 'E' && phrase[indexV] != 'I' && phrase[indexV] != 'O' && phrase[indexV] != 'U' && phrase[indexV] != 'a' && phrase[indexV] != 'e' && phrase[indexV] != 'i' && phrase[indexV] != 'o' && phrase[indexV] != 'u') && indexV < phrase.Length - 1)
                {
                    //stores consonants that come before the vowel found if applicable
                    constString = constString + phrase[indexV];
                    //increments the current index 
                    indexV++;
                }
                //while the index is still less than the phrases length, and a vowel is found, builds the translated string 
                if (indexV < phrase.Length - 1)
                {
                    //holds the string that contains the first vowel and everything after it
                    remainString = phrase.Substring(indexV);
                    //concantenates the entire string to be returned
                    //returnPhrase = returnPhrase + remainString + constString + "ay";
                    return returnPhrase + remainString + constString + "ay";
                }
                else
                {
                    return phrase;
                }
            }
            else
            {
                return phrase;
            }
        }
    }
}
