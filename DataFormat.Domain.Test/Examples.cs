namespace DataFormat.Domain.Test;

public static class Examples
{
    public const string ConfigCurrent = @"
+ ../schemas/family.schema

yeager_family: family
    people:
    - name: steve
      age: 32
    - name: rachel
      age: 23
      favoriteColor: blue
    location: USA
";

    public const string ConfigFuture = @"
+ current: ./family_current.config

yeager_family: current.yeager_family
    location: Canada";

    public const string DataCurrent = @"
yeager_family: family
    people:
    -   name: steve
        age: 32
    -   name: rachel
        age: 23
        favoriteColor: blue
    location: USA
";

    public const string DataFuture = @"
yeager_family: family # ../configs/family_current
    people:
    -   name: steve
        age: 32
    -   name: rachel
        age: 23
        favoriteColor: blue
    location: Canada # -> ../configs/family_future
";

    public const string Schema = @"
 family:
     people: person[]
     location: string

 person:
     name: string
     age: int
     favoriteColor: string?";
}