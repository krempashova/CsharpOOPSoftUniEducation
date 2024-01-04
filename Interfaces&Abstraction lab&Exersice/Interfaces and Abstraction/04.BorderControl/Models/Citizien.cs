using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizien: IIndentifable
{
    public Citizien(string name,int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }

}

