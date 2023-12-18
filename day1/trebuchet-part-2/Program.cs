namespace trebuchet_part_2;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("./trebuchet-part-2/input.txt");

        var total = 0;
        var textNumberDict = new Dictionary<string, int>() {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"zero", 0}
        };

        foreach (var line in lines)
        {
            string firstNumber = FindFirstNumber(line, textNumberDict);
            string lastNumber = FindLastNumber(line, textNumberDict);

            short.TryParse((firstNumber + lastNumber), out var number);
            total += number;
        }

        Console.WriteLine(total);
    }

    static string FindFirstNumber(string line, Dictionary<string, int> textNumberDict)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i].ToString();
            }

            foreach (var pair in textNumberDict)
            {
                if (line.Substring(0, i + 1).EndsWith(pair.Key))
                {
                    return pair.Value.ToString();
                }
            }
        }

        return "";
    }

    static string FindLastNumber(string line, Dictionary<string, int> textNumberDict)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i].ToString();
            }

            foreach (var pair in textNumberDict)
            {
                if (line.Substring(0, i + 1).EndsWith(pair.Key))
                {
                    return pair.Value.ToString();
                }
            }
        }

        return "";
    }
}
