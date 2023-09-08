using System.Text;

namespace Morse_Code
{
    /// <summary>
    /// The class with all the Morse code logic
    /// </summary>
    internal class Program
    {
        #region Morse Conversions
        /// <summary>
        /// Morse Conversions for letters (UPPERCASE & lowercase don't matter)
        /// </summary>
        public static readonly string[] morseLetterConversions = {
            ".-",       // A
            "-...",     // B
            "-.-.",     // C
            "-..",      // D
            ".",        // E
            "..-.",     // F
            "--.",      // G
            "....",     // H
            "..",       // I
            ".---",     // J
            "-.-",      // K
            ".-..",     // L
            "--",       // M
            "-.",       // N
            "---",      // O
            ".--.",     // P
            "--.-",     // Q
            ".-.",      // R
            "...",      // S
            "-",        // T
            "..-",      // U
            "...-",     // V
            ".--",      // W
            "-..-",     // X
            "-.--",     // Y
            "--.",      // Z
        };
        /// <summary>
        /// Morse Conversions for numbers
        /// </summary>
        public static readonly string[] morseNumberConversions =
        {
            "-----",    // 0
            ".----",    // 1
            "..---",    // 2
            "...--",    // 3
            "....-",    // 4
            ".....",    // 5
            "-....",    // 6
            "--...",    // 7
            "---..",    // 8
            "----."     // 9
        };
        /// <summary>
        /// Morse Conversions for punctuations
        /// </summary>
        public static readonly string[] morsePunctuationConversions1 =
        {
            "-.-.--",     // !
            ".-..-.",     // "
            string.Empty, // # (Doesn't exist in morse, need this for proper length)
            "...-..-",    // $
            "",           // % (Doesn't exist in morse, need this for proper length)
            ".-...",      // &
            ".----.",     // '
            "-.--.",      // (
            "-.--.-",     // )
            string.Empty, // * (Doesn't exist in morse, need this for proper length)
            ".-.-.",      // +
            "--..--",     // ,
            "-....-",     // -
            ".-.-.-",     // .
            "-..-."       // /
        };
        /// <summary>
        /// Morse Conversions for other punctuations
        /// </summary>
        public static readonly string[] morsePunctuationConversions2 =
        {
            "---...",     // :
            "-.-.-.",     // ;
            string.Empty, // < (Doesn't exist in morse, need this for proper length)
            "-...-",      // =
            string.Empty, // > (Doesn't exist in morse, need this for proper length)
            "..--..",     // ?
            ".--.-."      // @
        };
        #endregion

        /// <summary>
        /// Receives the string to translate, and then displays it with the corresponding beeps
        /// </summary>
        static void Main()
        {
            // Will infinitely prompt for another translation
            while (true)
            {
                // Initialize the empty string
                string word = string.Empty;

                Console.Write("Enter what you want to be translated (Characters like #*<>~` have no morse translation): ");

                // Check if the input is empty, and remind the user to enter something
                while (word == string.Empty)
                {
                    // Receive the inputted string
                    word = Console.ReadLine();

                    // If the string is empty, remind the users to enter a word
                    if (word == string.Empty) { Console.WriteLine("Please enter a word!"); }
                }

                // The StringBuilder which will be used to translate
                StringBuilder stringBuilder = new();

                foreach (char c in word)
                {
                    // Add the translated character to the StringBuilder
                    stringBuilder.Append(ConvertToMorse(char.ToUpper(c)) + " ");
                }

                // Display the Morse translation & play the Morse beep pattern
                PrintAndBeep(stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Converts each character in a string to Morse, using it's ASCII value
        /// </summary>
        /// <param name="letter">The character to translate</param>
        /// <returns>The Morse translation containing the dots & dashes</returns>
        public static string ConvertToMorse(char letter)
        {
            // If the ASCII value is a 'SPACE' or any other type of whitespace, insert this word break
            if (char.IsWhiteSpace(letter)) return "/";

            // If the ASCII value is between 48 & 57, it is a number
            if (char.IsDigit(letter)) return morseNumberConversions[letter - 48];

            if (char.IsPunctuation(letter) || char.IsSymbol(letter))
            {
                // If the ASCII value is between 33 & 47, it is in our 1st list of punctuation
                if (33 <= letter && letter <= 47) return morsePunctuationConversions1[letter - 33];

                // If the ASCII value is between 58 & 64, it is in the 2nd list of punctuation
                if (58 <= letter && letter <= 64) return morsePunctuationConversions2[letter - 58];
            }

            // If the ASCII value is between 65 & 90, it is a letter
            // Since we already converted everything to UPPERCASE, we don't need to differentiate
            if (char.IsLetter(letter)) return morseLetterConversions[letter - 65];

            // If the value is anything else (unsupported characters in Morse) inset a 'SPACE'
            else return " ";
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
                case '_': Console.Beep(800, 300); break;
                // If there is a space between characters, pause
                default: Thread.Sleep(100); break;
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
