using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
public class Challenge
{
    public static List<List<string>> ParseCsv(
     string csv,
     string separator,
     string quote
 )
    {
        Console.WriteLine($"csv: {JsonSerializer.Serialize(csv)} \n");
        Console.WriteLine($"separator: {JsonSerializer.Serialize(separator)} \n");
        Console.WriteLine($"quote: {JsonSerializer.Serialize(quote)} \n");

        quote = string.IsNullOrEmpty(quote) ? "\"" : quote;
        separator = string.IsNullOrEmpty(separator) ? "," : separator;
        string newLine = "\n";

        List<string> columns = new List<string>();
        List<List<string>> rows = new List<List<string>>();
        bool hasQuoteInValue = false;
        int quantityQuotes = 0;
        //bool invalidCloseQuote = false;
        string currentString = string.Empty;
        if (csv.Length == 0)
        {
            rows.Add(new List<string> { "" });
        }

        void handleAddColum()
        {
            columns.Add(currentString);
        }


        for (int i = 0; i < csv.Length; i++)
        {

            string currentChar = csv[i].ToString();

            if (currentChar == quote)
            {
                quantityQuotes++;
            }

            if (!hasQuoteInValue && currentChar == quote)
            {
                hasQuoteInValue = true;
            }

            if (quantityQuotes % 2 == 0 && hasQuoteInValue && (currentChar == separator || currentChar == newLine) && csv[i - 1].ToString() == quote)
            {
                currentString = HandleQuotes(currentString, quote);
                hasQuoteInValue = false;
                quantityQuotes = 0;
            }
            if (!hasQuoteInValue && currentChar.ToString() == newLine)
            {
                columns.Add(currentString);
                rows.Add(columns);
                columns = new List<string>();
                currentString = string.Empty;
                continue;
            }




            if (!hasQuoteInValue && currentChar.ToString() == separator)
            {
                columns.Add(currentString);
                currentString = string.Empty;
                continue;
            }

            currentString += currentChar;
            if (i + 1 == csv.Length)
            {
                currentString = HandleQuotes(currentString, quote);
                columns.Add(currentString);
                rows.Add(columns);
            }
        }
        return rows;
    }

    private static string HandleQuotes(string currentString, string quote)
    {
        var indexFirstQuote = currentString.IndexOf(quote);
        if (indexFirstQuote >= 0)
            currentString = currentString.Remove(indexFirstQuote, quote.Length).Insert(indexFirstQuote, "");

        var indexLastQuote = currentString.LastIndexOf(quote);
        if (indexLastQuote >= 0)
            currentString = currentString.Remove(indexLastQuote, quote.Length).Insert(indexLastQuote, "");

        bool handledAlternateQuotes = false;


        if (!handledAlternateQuotes && currentString.Contains(string.Concat(quote, quote)))
        {
            handledAlternateQuotes = true;
            currentString = currentString.Replace(string.Concat(quote, quote), quote);
        }

        if (!handledAlternateQuotes && currentString.Contains(quote))
        {
            handledAlternateQuotes = true;
            currentString = currentString.Replace(quote, string.Concat(quote, quote));
        }

        return currentString;
    }

}
