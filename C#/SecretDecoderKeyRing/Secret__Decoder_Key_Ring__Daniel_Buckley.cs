using System;
using System.IO;

namespace SecretDecoderKeyRing
{
    public class Secret_Decoder_Key_Ring_Daniel_Buckley
    {
        public static string Decode(string chainInUpperCase, string encodedText)
        {
            string chainInLowerCase = chainInUpperCase.ToLower();
            string result = "";

            for (int i = 0; i < encodedText.Length; i++)
            {
                for (int j = 0; j < chainInUpperCase.Length - 1; j++)
                {
                    if (encodedText[i] == chainInUpperCase[j] && chainInUpperCase[j + 1] == '-')
                    {
                        result += chainInUpperCase[j + 2];
                    }
                    else if (encodedText[i] == chainInLowerCase[j] && chainInLowerCase[j + 1] == '-')
                    {
                        result += chainInLowerCase[j + 2];
                    }
                }
                if (encodedText[i] == ' ')
                {
                    result += " ";
                }
                else if (IsSymbol(encodedText[i]))
                {
                    result += encodedText[i];
                }
            }

            return result;
        }

        public static bool IsSymbol(char character)
        {
            bool isValid = false;

            if (character.Equals('!') || character.Equals('.') ||
                character.Equals('?') || character.Equals('#'))
            {
                isValid = true;
            }
            return isValid;
        }
    }

    class MainClass
    {
        // Run Main() without debugging i.e. CTRL + F5
        static void Main()
        {
            // ***IMPORTANT*** When running, change the relative path to match your machine
            // E.G. string relativePathToInput = @"C:\Users\Daniel\Desktop\GitHub Projects\MicrosoftCodingCompetition2016\C#\SecretDecoderKeyRing\InputForSecretDecoderProblem\input.txt"
            // E.G. string relativePathToOutput = @"C:\Users\Daniel\Desktop\GitHub Projects\MicrosoftCodingCompetition2016\C#\SecretDecoderKeyRing\OutputForSecretDecoderProblem\output.txt";
            // Otherwise the below code will throw errors due to filepaths and files not being found
            string relativePathToInput = @"Put relative path to input.txt here on local machine";
            string relativePathToOutput = @"Put relative path to output.txt here on local machine";

            string[] encodedText = File.ReadAllLines(relativePathToInput);
            // Get the result for first two lines in input.txt
            string result = Secret_Decoder_Key_Ring_Daniel_Buckley.Decode(encodedText[0], encodedText[1]);

            // Get the result for last two lines in input.txt and append to result
            result += "\n " + Secret_Decoder_Key_Ring_Daniel_Buckley.Decode(encodedText[2], encodedText[3]);
            Console.WriteLine(result);

            // Insert result into file
            File.WriteAllText(relativePathToOutput, result);
        }
    }
}