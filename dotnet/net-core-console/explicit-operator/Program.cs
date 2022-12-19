using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void Main()
{
    Classedomain classedomain = new Classedomain()
    {
        Id = 1,
        Name = "teste"
    };

    ClasseDomainDto dto = (ClasseDomainDto)classedomain;

    Console.WriteLine(JsonSerializer.Serialize(dto));

}
Main();

public class Classedomain
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class ClasseDomainDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public static explicit operator ClasseDomainDto(Classedomain model)
    {
        return new ClasseDomainDto
        {
            Id = model.Id,
            Name = model.Name,
        };
    }
}



