using System.Collections;

namespace MyProject.Test;

public class ClassDataTest
{
    [Theory]
    [ClassData(typeof(TheoryClassData))]
    [ClassData(typeof(TheoryTypedDataClass))]
    public void Should_be_equal(int firstNumber, int secondNumber, bool shouldBeEqual)
    {
        if (shouldBeEqual)
            Assert.Equal(firstNumber, secondNumber);
        else
            Assert.NotEqual(firstNumber, secondNumber);
    }

    public class TheoryClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, false };
            yield return new object[] { 2, 2, true };
            yield return new object[] { 12, 5, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TheoryTypedDataClass : TheoryData<int, int, bool>
    {
        public TheoryTypedDataClass()
        {
            Add(20, 50, false);
            Add(25, 25, true);
            Add(50, 50, true);
        }
    }
}