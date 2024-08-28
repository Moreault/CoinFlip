namespace CoinFlip.Tests;

[TestClass]
public sealed class ValueFlipTests : Tester
{
    [TestMethod]
    public void Flip_Always_ReturnEitherValues()
    {
        //Arrange
        var heads = Dummy.Create<string>();
        var tails = Dummy.Create<string>();


        //Act
        var result = new List<string?>();
        for (var i = 0; i < 20; i++)
            result.Add(Coin.Flip(heads, tails));

        //Assert
        result.Should().Contain(heads);
        result.Should().Contain(tails);
    }

    [TestMethod]
    public void FlipOrDefault_Always_OnlyReturnValueSometimes()
    {
        //Arrange
        var heads = Dummy.Create<string>();

        //Act
        var result = new List<string?>();
        for (var i = 0; i < 20; i++)
            result.Add(Coin.FlipOrDefault(heads));

        //Assert
        result.Should().Contain(heads);
        result.Should().Contain(default(string));
    }
}