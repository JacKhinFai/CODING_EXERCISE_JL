using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter Text (or 'exit' to quit): ");
            string text = Console.ReadLine();
            if (exitOrNot(text))
            {
                break;
            }
            Console.Write("Enter Subtext: ");
            string subtext = Console.ReadLine();
            var positions = matchPositions(text, subtext);

            try
            {
                Console.WriteLine(subtext + " " + string.Join(", ", positions) ?? null);
            }
            catch { }
        }
        Console.WriteLine("Program closed");
    }

    static IEnumerable<int> matchPositions(string text, string subtext)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
        {
            return Enumerable.Empty<int>();
        }

        var lowerText = text.ToLower();
        var lowerSubtext = subtext.ToLower();
        int subLength = lowerSubtext.Length;

        return Enumerable.Range(0, lowerText.Length - subLength + 1)
                        .Where(i =>
                        {
                            for (int j = 0; j < subLength; j++)
                            {
                                if (lowerText[i + j] != lowerSubtext[j])
                                {
                                    return false;
                                }

                            }
                            return true;
                        }) //Would use SubString here (lowerText.Substring(i, subLength) == lowerSubtext)
                        .Select(i => i + 1);
    }

    static bool exitOrNot(string text)
    {
        if (string.Equals(text, "exit", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }
}