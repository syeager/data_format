namespace DataFormat.Domain;

public class SchemaLoader
{
    public async Task<DataSchema> LoadFromFileAsync(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath);
        var schema = await LoadAsync(lines);
        return schema;
    }

    public async Task<DataSchema> LoadAsync(string[] lines)
    {
        var schema = new DataSchema();

        for (var i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i])) continue;

            var schemaObject = StartObject(lines[i]);
            schema.DataSchemaObjects.Add(schemaObject);

            while (true)
            {
                var nextLine = lines[++i];
                if (nextLine.EndsWith(':') || string.IsNullOrWhiteSpace(nextLine))
                {
                    --i;
                    break;
                }

                var property = ReadProperty(nextLine);
                schemaObject.Properties.Add(property);
            }
        }

        return schema;
    }

    private DataSchemaObject StartObject(string line)
    {
        return new DataSchemaObject
        {
            Name = line.TrimStart()[..^1],
            Properties = new List<DataSchemaProperty>()
        };
    }

    private DataSchemaProperty ReadProperty(string line)
    {
        var segments = line.Trim().Split(':');
        var typeString = segments[1];

        var isOptional = typeString.EndsWith('?');
        if (isOptional)
        {
            typeString = typeString[..^1];
        }

        var isList = typeString.EndsWith(']');
        if (isList)
        {
            typeString = typeString[..^2];
        }

        return new DataSchemaProperty
        {
            Name = segments[0],
            Type = typeString,
            IsList = typeString.EndsWith(']')
        };
    }
}