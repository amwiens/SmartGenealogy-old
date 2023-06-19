namespace SmartGenealogy.Models;

public class FontIconModel
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return Name;
    }
}