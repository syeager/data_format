namespace DataFormat.Domain;

public class DataSchemaObject
{
    // name
    public string Name { get; set; }
    // properties
    public List<DataSchemaProperty> Properties { get; set; }
    public override string ToString() => $"{Name}: object";
}


/*
 * force schemas
 * C# representation
 * Reference object in same and other files
 * override referenced object properties
 * uses environment variables and parameters
 * comments
 *
 *
 * Schema.edfs
 *  person:
 *    name: string
 *    age: int
 * family:
 *   girlfriend: person
 *   people: person[]
 *
 *
 * steve-family.edf
 * + Schema.edfs
 *
 * family: steve-family
 * girlfriend:
 *   name: rachel
 *   age: 23
 * people:
 *   name: steve
 *   age: 31
 *   name: rachel
 *   age: 23
 *
 * rachel-family.edf
 * [family]: rachel-family
 * > steve-family
 * girlfriend:
 *   age: 24
 * 
 */