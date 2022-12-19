using System.Linq;
public class Challenge
{
    public static string OrderWeight(string str)
    {
        var listNumeric = str.Split(' ').Select(currentNumber =>
        {

            var weight = currentNumber.ToCharArray().Select(e => int.Parse(e.ToString())).Sum(s => s);
            return new
            {
                Weight = weight,
                Number = currentNumber
            };
        }).OrderBy(e => e.Weight).ThenBy(e => e.Number);

        return string.Join(' ', listNumeric.Select(e => e.Number));


    }
}