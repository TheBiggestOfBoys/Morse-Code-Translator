using System.Text;

namespace Morse_Code
{
    internal class Program
    {
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

        static void Main()
        {
            Console.Write("Enter what you want to be translated (Characters like #*<>~` have no morse translation): ");
            string word = Console.ReadLine();

            if (word == string.Empty) { Console.WriteLine("Please enter a word!"); }

            else
            {
                StringBuilder stringBuilder = new();

                for (int x = 0; x < word.Length; x++)
                {
                    stringBuilder.Append(ConvertToMorse(char.ToUpper(word[x])) + " ");
                }

                Console.WriteLine(stringBuilder);
                DitDah(stringBuilder);
            }
        }

        public static string ConvertToMorse(char letter)
        {
            if (65 <= letter && letter <= 90) { return morseLetterConversions[letter - 65]; }

            if (48 <= letter && letter <= 57) { return morseNumberConversions[letter - 48]; }

            if (33 <= letter && letter <= 47) { return morsePunctiationConversions1[letter - 33]; }

            if (58 <= letter && letter <= 64) { return morsePunctuationConversions2[letter - 58]; }

            if (letter == 32) { return " | "; }

            else { return " "; }
        }

        public static void DitDah(StringBuilder morse)
        {
            for (int i = 0; i < morse.Length; i++)
            {
                if (morse[i].Equals('.')) { Console.Beep(800, 100); }

                if (morse[i].Equals('-')) { Console.Beep(800, 300); }

                else { Thread.Sleep(100); }
            }
        }
    }
}
