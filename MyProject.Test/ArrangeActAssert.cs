namespace MyProject.Test;

public class ArrangeActAssert
{
    [Fact]
    public void Should_be_equal()
    {
        //Arrange
        var firstNumber = 5;
        var secondNumber = 7;
        var sum = 12;

        //Act
        var result=firstNumber+ secondNumber;

        //Assert
        Assert.Equal(sum, result);
    }
}