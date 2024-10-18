using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Morse_Code
{
    /// <summary>
    /// The class with all the Morse code logic
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Dictionary containing all translations.
        /// Non-supported translations are just " ".
        /// </summary>
        public static readonly Dictionary<char, string> morseConversions = new()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
            {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
            {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"}, {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."},

            {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."},
            {'7', "--..."}, {'8', "---.."}, {'9', "----."},

            {'!', "-.-.--"}, {'"', ".-..-."}, {'#', " "}, {'$', "...-..-"}, {'%', " "}, {'&', ".-..."},
            {'\'', ".----."}, {'(', "-.--."}, {')', "-.--.-"}, {'*', " "}, {'+', ".-.-."}, {',', "--..--"},
            {'-', "-....-"}, {'.', ".-.-.-"}, {'/', "-..-."}, {':', "---..."}, {';', "-.-.-."}, {'<', " "},
            {'=', "-...-"}, {'>', " "}, {'?', "..--.."}, {'@', ".--.-."},

            {' ', " / "}
        };

        /// <summary>
        /// Receives the string to translate, and then displays it with the corresponding beeps
        /// </summary>
        static void Main()
        {
            // Will infinitely prompt for another translation
            while (true)
            {
                Console.Write("Enter what you want to be translated (Characters like #*<>~` have no morse translation): ");

                // Check if the input is empty, and remind the user to enter something
                string word = Console.ReadLine();

                // The StringBuilder which will be used to translate
                StringBuilder stringBuilder = new();

                foreach (char c in word)
                {
                    // Add the translated character to the StringBuilder
                    stringBuilder.Append(morseConversions[char.ToUpper(c)]);
                    stringBuilder.Append(' ');
                }

                // Display the Morse translation & play the Morse beep pattern
                PrintAndBeep(stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Reads the character and plays the appropriate beep
        /// </summary>
        /// <param name="morse">The character to read</param>
        public static void DitDah(char morse)
        {
            switch (morse)
            {
                // If the character is a dot (dit), play the short beep
                case '.': Console.Beep(800, 100); break;
                // If the character is a dash (dah), play the long beep
                case '-': Console.Beep(800, 300); break;
                // If there is a space between characters, "pause"
                default: Thread.Sleep(400); break;
            }
        }

        /// <summary>
        /// Print the characters and plays the corresponding beep
        /// </summary>
        /// <param name="morse">The string to read from</param>
        public static void PrintAndBeep(string morse)
        {
            foreach (char c in morse)
            {
                Console.Write(c);
                DitDah(c);
            }
            Console.WriteLine();
        }
    }
}
