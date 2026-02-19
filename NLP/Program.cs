using System;
using System.IO;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("C:\\Users\\dedoa\\OneDrive\\Desktop\\Uni\\Fundimintals of AI module\\Main portfilio\\Treasureisland (1).txt");
            
            int printableCharactersCount = CountPrintableCharacters(input);
            int whiteSpaceCount = CountWhiteSpace(input);
            int vowelsCount = CountVowels(input);
            int consonantsCount = CountConsonants(input);
            int[] vowelsFrequency = new int[5];
            CalculateVowelsFrequency(input, vowelsFrequency);

            
            Console.WriteLine("Number of printable characters: " + printableCharactersCount);
            Console.WriteLine("Number of white space characters: " + whiteSpaceCount);
            Console.WriteLine("Number of vowels: " + vowelsCount);
            Console.WriteLine("Number of consonants: " + consonantsCount);
            Console.WriteLine("Frequency of each vowel:");
            Console.WriteLine("A: " + vowelsFrequency[0]);
            Console.WriteLine("E: " + vowelsFrequency[1]);
            Console.WriteLine("I: " + vowelsFrequency[2]);
            Console.WriteLine("O: " + vowelsFrequency[3]);
            Console.WriteLine("U: " + vowelsFrequency[4]);
        }

        
        static int CountPrintableCharacters(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c) || char.IsWhiteSpace(c))
                {
                    count++;
                }
            }
            return count;
        }

        
        static int CountWhiteSpace(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    count++;
                }
            }
            return count;
        }

        static int CountVowels(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if ("AEIOUaeiou".IndexOf(c) != -1)
                {
                    count++;
                }
            }
            return count;
        }

        static int CountConsonants(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsLetter(c) && "AEIOUaeiou".IndexOf(c) == -1)
                {
                    count++;
                }
            }
            return count;
        }

        static void CalculateVowelsFrequency(string input, int[] frequencies)
        {
            foreach (char c in input)
            {
                if ("AEIOUaeiou".IndexOf(c) != -1)
                {
                    switch (char.ToUpper(c))
                    {
                        case 'A':
                            frequencies[0]++;
                            break;
                        case 'E':
                            frequencies[1]++;
                            break;
                        case 'I':
                            frequencies[2]++;
                            break;
                        case 'O':
                            frequencies[3]++;
                            break;
                        case 'U':
                            frequencies[4]++;
                            break;
                    }
                }
            }
        }
    }
}