namespace MyProject.Test;

public class AssertionTest
{
    [Fact]
    public void Exploring_xUnit_assertions()
    {
        object obj1 = new Person { Name = "Object 1" };
        object obj2 = new Person { Name = "Object 1" };
        object obj3 = obj1;
        object? obj4 = default(Person);

        Assert.Same(obj1, obj3);
        Assert.NotSame(obj2, obj3);
        Assert.Equal(obj1, obj2);
        Assert.Null(obj4);
        Assert.NotNull(obj3);

        var instanceOfPerson = Assert.IsType<Person>(obj1);
        Assert.Equal("Object 1", instanceOfPerson.Name);

        var exception = Assert.Throws<SomeCustomException>(() =>OperationThatThrows("Toto"));

        Assert.Equal("Toto", exception.Name);

        static void OperationThatThrows(string name) => throw new SomeCustomException { Name = name };
    }

    public record class Person
    {
        public string Name { get; set; }
    }

    private class SomeCustomException : Exception
    {
        public string? Name { get; set; }
    }
}