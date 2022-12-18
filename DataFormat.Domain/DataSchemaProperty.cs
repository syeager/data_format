namespace DataFormat.Domain;

public class DataSchemaProperty
{
    // name
    public string Name { get; set; }
    // type
    public string Type { get; set; }
    public bool IsOptional { get; set; }
    public bool IsList { get; set; }

    public override string ToString() => $"{Name}: {Type}";
}