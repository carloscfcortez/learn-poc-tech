using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;


class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello World");
        // string stx = "1,\"two was here\",3\n4,5,6 ";
        // //var result = Challenge.ParseCsv("1,2,3\n4,'this ''is''\na test',6 ", ",", "'");

        // string delimiter = ",";
        // string quote = "'";

        var result = Challenge.ParseCsv("\\a \\\\string\\\\ using \\\\ as the quote\\.\\multi\nline\\.\n1.2.\\3.4\\", ".", "\\");
        //var result = Challenge.ParseCsv("1,\"two \"\"quote\"\"\",3\n4,5,6", ",", "\"");

        string jsonString = JsonSerializer.Serialize(result);

        Console.WriteLine(jsonString);

        // List<string> columns = new List<string>();
        // List<List<string>> rows = new List<List<string>>();
        // string currentString = "";
        // bool hasQuoteInValue = false;
        // bool invalidCloseQuote = false;
        // for (int i = 0; i < stx.Length; i++)
        // {

        //     char currentChar = stx[i];

        //     if (currentChar.ToString() == quote)
        //     {
        //         hasQuoteInValue = true;
        //     }

        //     if (!hasQuoteInValue && currentChar.ToString() == "\n")
        //     {
        //         columns.Add(currentString);
        //         rows.Add(columns);
        //         columns = new();
        //         currentString = string.Empty;
        //         continue;
        //     }



        //     if (currentChar.ToString() == delimiter)
        //     {
        //         //check last character if is a close quote
        //         if (hasQuoteInValue)
        //         {
        //             string lastCharacter = stx[i - 1].ToString();
        //             if (lastCharacter != quote)
        //             {
        //                 //DO ANY TREATMENT FOR INVALID CLOSE QUOTES
        //                 invalidCloseQuote = true;
        //             }

        //             var indexFirstQuote = currentString.IndexOf(quote);
        //             if (indexFirstQuote >= 0)
        //                 currentString = currentString.Remove(indexFirstQuote, quote.Length).Insert(indexFirstQuote, "");

        //             var indexLastQuote = currentString.LastIndexOf(quote);
        //             if (indexLastQuote >= 0)
        //                 currentString = currentString.Remove(indexLastQuote, quote.Length).Insert(indexLastQuote, "");

        //         }
        //         columns.Add(currentString);
        //         currentString = string.Empty;
        //         continue;
        //     }

        //     if (currentChar.ToString() != delimiter)
        //     {
        //         currentString += currentChar;
        //         if (i + 1 == stx.Length)
        //         {
        //             rows.Add(columns);
        //         }
        //     }


        // }

        // string jsonString = JsonSerializer.Serialize(rows);
        // Console.WriteLine(jsonString);



    }
}





