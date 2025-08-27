namespace GoalsGalore.Model;

public class Person(string name, string lastName)
{
    public string FirstName { get; set; } = name;

    public string Surname { get; set; } = lastName;
}