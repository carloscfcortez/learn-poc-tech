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


        var result = Challenge.OrderWeight("");
        //var result = Challenge.ParseCsv("1,\"two \"\"quote\"\"\",3\n4,5,6", ",", "\"");

        string jsonString = JsonSerializer.Serialize(result);

        Console.WriteLine(jsonString);



    }
}





