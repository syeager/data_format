namespace DataFormat.Domain.Test
{
    public class Tests
    {
        private SchemaLoader testObj;

        [SetUp]
        public void Setup()
        {
            testObj = new SchemaLoader();
        }

        [Test]
        public async Task Test1()
        {
            var schemaJson =
@"family:
    people: person[]
    location: string

person:
    name: string
    age: int
    favoriteColor: string?
";
            var schema = await testObj.LoadAsync(schemaJson.Split(Environment.NewLine));
            Assert.IsNotNull(schema);
        }
    }
}