using System.Runtime.Serialization;

namespace MyProject.Test;

public class MemberDataTest
{
    public static IEnumerable<object[]> Data => new[]
    {
        new object[]{ 5,10,false},
        new object[]{ 5,5,true},
        new object[]{ 7,5,false},
    };

    public static TheoryData<int, int, bool> TypedData => new TheoryData<int, int, bool>
    {
        {99,100,false },
        {99,95,false},
        {85,85,true},
    };

    [Theory]
    [MemberData(nameof(Data))]
    [MemberData(nameof(TypedData))]
    [MemberData(nameof(ExternalData.GetData), 20, MemberType = typeof(ExternalData))]
    [MemberData(nameof(ExternalData.TypedData), MemberType = typeof(ExternalData))]
    public void Should_be_equal(int firstNumber, int secondNumber, bool shouldBeEqual)
    {
        if (shouldBeEqual)
            Assert.Equal(firstNumber, secondNumber);
        else
            Assert.NotEqual(firstNumber, secondNumber);
    }

    public class ExternalData
    {
        public static IEnumerable<object[]> GetData(int start) => new[]
        {
            new object[]{start,start,true},
            new object[]{start/2,start/2,true},
            new object[]{start+5,start,false},
        };

        public static TheoryData<int, int, bool> TypedData = new TheoryData<int, int, bool>
        {
            {1,1,true},
            {300,30,false},
            {5,5,true},
            {7,7,true},
            {7,5,false},
        };
    }
}