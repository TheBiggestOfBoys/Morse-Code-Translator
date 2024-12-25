using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace NATO_Phonetic
{
    internal class Program
    {
        /// <summary>
        /// Dictionary containing all translations.
        /// Non-supported translations are just " ".
        /// </summary>
        public static readonly Dictionary<char, string> PhoneticConversions = new()
        {
            {'A', "Alpha"},
            {'B', "Bravo"},
            {'C', "Charlie"},
            {'D', "Delta"},
            {'E', "Echo"},
            {'F', "Foxtrot"},
            {'G', "Golf"},
            {'H', "Hotel"},
            {'I', "India"},
            {'J', "Juliett"},
            {'K', "Kilo"},
            {'L', "Lima"},
            {'M', "Mike"},
            {'N', "November"},
            {'O', "Oscar"},
            {'P', "Papa"},
            {'Q', "Quebec"},
            {'R', "Romeo"},
            {'S', "Sierra"},
            {'T', "Tango"},
            {'U', "Uniform"},
            {'V', "Victor"},
            {'W', "Whiskey"},
            {'X', "Xray"},
            {'Y', "Yankee"},
            {'Z', "Zulu"}
        };

        /// <summary>
        /// Receives the string to translate, and then displays it with the corresponding beeps
        /// </summary>
        static void Main()
        {
            // Will infinitely prompt for another translation
            while (true)
            {
                Console.Write("Enter what you want to be spoken (only letters and numbers will be read): ");

                // Check if the input is empty, and remind the user to enter something
                string messages = Console.ReadLine();

                // Display the Morse translation & play the Morse beep pattern
                PrintAndSpeak(messages);
            }
        }

        /// <summary>
        /// Print the characters and plays the corresponding beep
        /// </summary>
        /// <param name="message">The string to read from</param>
        public static void PrintAndSpeak(string message)
        {
            SpeechSynthesizer synthesizer = new();

            string[] words = message.Split();
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (char.IsLetter(c))
                    {
                        string phonetic = PhoneticConversions[char.ToUpper(c)];
                        Console.Write(phonetic + ' ');
                        synthesizer.Speak(phonetic);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
