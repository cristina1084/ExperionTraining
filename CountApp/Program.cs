/*A sample application that can read a long text and list down the number of words, characters, 
  white spaces, special characters, and vowels in the text.*/

using System;

namespace CountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String text;
            Console.Write("Enter a long text: ");
            text = Console.ReadLine().ToLower();
            char[] textArray = text.ToCharArray();
            int vowels = 0, words = 1, spChars = 0, whiteSpaces = 0;
            foreach (var c in textArray)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    vowels += 1;
                if (c == ' ')
                {
                    whiteSpaces += 1;
                    words += 1;
                }
                if (!((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c==' '))
                    spChars += 1;
            }
            Console.WriteLine("Words: " + words);
            Console.WriteLine("Characters: " + text.Length);
            Console.WriteLine("Whitespaces: " + whiteSpaces);
            Console.WriteLine("Special Characters: " + spChars);
            Console.WriteLine("Vowels: " + vowels);
        }
    }
}
