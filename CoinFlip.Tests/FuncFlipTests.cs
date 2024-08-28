namespace CoinFlip.Tests;

[TestClass]
public sealed class FuncFlipTests : Tester
{
    [TestMethod]
    public void WhenHeadsIsNull_Throw()
    {
        //Arrange
        Func<string> heads = null!;
        var tails = Dummy.Create<Func<string>>();

        //Act
        var action = () => Coin.Flip(heads, tails);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(heads));
    }

    [TestMethod]
    public void WhenTailsIsNull_Throw()
    {
        //Arrange
        var heads = Dummy.Create<Func<string>>();
        Func<string> tails = null!;

        //Act
        var action = () => Coin.Flip(heads, tails);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(tails));
    }

    [TestMethod]
    public void WhenHeadsAndTailsAreNotNull_ReturnAny()
    {
        //Arrange
        var heads = Dummy.Create<string>();
        var tails = Dummy.Create<string>();

        //Act
        var results = new List<string?>();
        for (var i = 0; i < 10; i++)
            results.Add(Coin.Flip(() => heads, () => tails));

        //Assert
        results.Should().Contain(heads);
        results.Should().Contain(tails);
    }

    [TestMethod]
    public void FlipOrDefault_WhenHeadsIsNull_Throw()
    {
        //Arrange
        Func<string> heads = null!;

        //Act
        var action = () => Coin.FlipOrDefault(heads);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(heads));
    }

    [TestMethod]
    public void FlipOrDefault_WhenHeadsIsNotNull_ReturnEitherValueOrDefault()
    {
        //Arrange
        var heads = Dummy.Create<string>();

        //Act
        var results = new List<string?>();
        for (var i = 0; i < 10; i++)
            results.Add(Coin.FlipOrDefault(() => heads));

        //Assert
        results.Should().Contain(heads);
        results.Should().Contain(default(string));
    }
}