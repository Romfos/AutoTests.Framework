namespace AutoTests.Framework.Models.Attributes;

public class NameAttribute : ModelPropertyAttribute
{
    public string Name { get; }

    public NameAttribute(string name)
    {
        Name = name;
    }
}
