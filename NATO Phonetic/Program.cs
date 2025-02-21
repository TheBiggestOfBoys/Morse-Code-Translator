using System;
using System.Speech.Synthesis;

namespace NATO_Phonetic
{
	internal class Program
	{
		/// <summary>
		/// Converts a character to its NATO phonetic alphabet equivalent.
		/// </summary>
		/// <param name="c">The character to convert.</param>
		/// <returns>The NATO phonetic alphabet equivalent of the character.</returns>
		public static string GetPhoneticCode(char c) => c switch
		{
			'A' or 'a' => "Alpha",
			'B' or 'b' => "Bravo",
			'C' or 'c' => "Charlie",
			'D' or 'd' => "Delta",
			'E' or 'e' => "Echo",
			'F' or 'f' => "Foxtrot",
			'G' or 'g' => "Golf",
			'H' or 'h' => "Hotel",
			'I' or 'i' => "India",
			'J' or 'j' => "Juliet",
			'K' or 'k' => "Kilo",
			'L' or 'l' => "Lima",
			'M' or 'm' => "Mike",
			'N' or 'n' => "November",
			'O' or 'o' => "Oscar",
			'P' or 'p' => "Papa",
			'Q' or 'q' => "Quebec",
			'R' or 'r' => "Romeo",
			'S' or 's' => "Sierra",
			'T' or 't' => "Tango",
			'U' or 'u' => "Uniform",
			'V' or 'v' => "Victor",
			'W' or 'w' => "Whiskey",
			'X' or 'x' => "Xray",
			'Y' or 'y' => "Yankee",
			'Z' or 'z' => "Zulu",
			_ => " "
		};

		/// <summary>
		/// Receives the string to translate, and then displays it with the corresponding speech
		/// </summary>
		static void Main()
		{
			// Will infinitely prompt for another translation
			while (true)
			{
				Console.Write("Enter what you want to be spoken (only letters and numbers will be read): ");

				// Check if the input is empty, and remind the user to enter something
				string messages = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(messages))
				{
					Console.WriteLine("Please enter a valid string.");
					continue;
				}

				// Display the NATO phonetic translation & play the speech
				PrintAndSpeak(messages);
			}
		}

		/// <summary>
		/// Print the characters and plays the corresponding speech
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
						string phonetic = GetPhoneticCode(c);
						Console.WriteLine(phonetic);
						synthesizer.Speak(phonetic);
					}
					else if (char.IsDigit(c))
					{
						Console.WriteLine(c);
						synthesizer.Speak(c.ToString());
					}
				}
				Console.WriteLine();
			}
		}
	}
}
