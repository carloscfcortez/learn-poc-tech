using System.Collections.Generic;
using System.Linq;
using System;

public class Challenge
{
    public static string FindRoutes(List<List<string>> routes)
    {
        var origin = GetOrigin(routes);

        if (origin == null)
            throw new Exception("Can't identify the origin place");

        string currentPlace = origin[0];
        string nextPlace = origin[1];

        string result = string.Concat(currentPlace, ", ", nextPlace);
        for (int i = 0; i < routes.Count; i++)
        {
            var arrRoute = routes.FirstOrDefault(e => e[0] == nextPlace);
            if (arrRoute != null)
            {
                nextPlace = arrRoute[1];
                result = string.Concat(result, ", ", nextPlace);
            }
        }

        return result;
    }

    private static List<string> GetOrigin(List<List<string>> routes)
    {
        foreach (var route in routes)
        {
            var origin = route[0];
            if (!routes.Any(e => e[1] == origin))
            {
                return route;
            }
        }
        return null;
    }
}