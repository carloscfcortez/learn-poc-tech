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


        // List<List<string>> routes = new List<List<string>>
        // {
        //     new List<string> {"USA", "BRA"},
        //     new List<string> {"JPN", "PHL"},
        //     new List<string> {"BRA", "UAE"},
        //     new List<string> {"UAE", "JPN"},
        // };


        List<List<string>> routes = new List<List<string>>
        {
            new List<string> {"Chicago", "Winnipeg"},
            new List<string> {"Halifax", "Montreal"},
            new List<string> {"Montreal", "Toronto"},
            new List<string> {"Toronto", "Chicago"},
            new List<string> {"Winnipeg", "Seattle"},
        };
        var result = Challenge.FindRoutes(routes);
        //var result = Challenge.ParseCsv("1,\"two \"\"quote\"\"\",3\n4,5,6", ",", "\"");

        string jsonString = JsonSerializer.Serialize(result);

        Console.WriteLine(jsonString);



    }
}





