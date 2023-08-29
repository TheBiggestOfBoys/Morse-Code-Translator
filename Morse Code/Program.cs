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
        public static readonly string[] morsePunctiationConversions1 =
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
            // Receive the user's inputted string
            Console.Write("Enter what you want to be translated (Characters like #*<>~` have no morse translation): ");
            string word = Console.ReadLine();

            if (word == string.Empty) { Console.WriteLine("Please enter a word!"); }

            else
            {
                // The StringBuilder which will be used to translate
                StringBuilder stringBuilder = new();

                foreach (char c in word)
                {
                    // Add the translated character to the StringBuilder
                    stringBuilder.Append(ConvertToMorse(char.ToUpper(c)) + " ");
                }

                // Display the Morse translation
                Console.WriteLine(stringBuilder);
                // Play the Morse beep pattern
                DitDah(stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Converts each character in a string to Morse, using it's ASCII value
        /// </summary>
        /// <param name="letter">The character to translate</param>
        /// <returns>The Morse translation containing the dots & dashes</returns>
        public static string ConvertToMorse(char letter)
        {
            // If the ASCII value is a 'SPACE', insert this word break
            if (letter == 32) { return " / "; }

            // If the ASCII value is between 33 & 47, it is in our 1st list of punctuation
            if (33 <= letter && letter <= 47) { return morsePunctiationConversions1[letter - 33]; }

            // If the ASCII value is between 48 & 57, it is a number
            if (48 <= letter && letter <= 57) { return morseNumberConversions[letter - 48]; }

            // If the ASCII value is between 58 & 64, it is in the 2nd list of punctuation
            if (58 <= letter && letter <= 64) { return morsePunctuationConversions2[letter - 58]; }

            // If the ASCII value is between 65 & 90, it is a letter
            if (65 <= letter && letter <= 90) { return morseLetterConversions[letter - 65]; }

            // If the value is anything else (unsupported characters in Morse) inset a 'SPACE'
            else { return " "; }
        }

        /// <summary>
        /// Reads the string and plays the beep for the appropriate amount
        /// </summary>
        /// <param name="morse">The String to read from</param>
        public static void DitDah(string morse)
        {
            // Loop through each character in the StringBuilder converted to a string
            foreach (char c in morse)
            {
                // If the character is a dot (dit), play the short beep
                if (c.Equals('.')) { Console.Beep(800, 100); }

                // If the character is a dash (dah), play the long beep
                if (c.Equals('-')) { Console.Beep(800, 300); }

                // If there is a space between characters, pause
                else { Thread.Sleep(100); }
            }
        }
    }
}
