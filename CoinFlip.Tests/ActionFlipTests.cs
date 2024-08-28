namespace CoinFlip.Tests;

[TestClass]
public sealed class ActionFlipTests : Tester
{
    [TestMethod]
    public void Flip_WhenHeadsIsNull_Throw()
    {
        //Arrange
        Action heads = null!;
        var tails = Dummy.Create<Action>();

        //Act
        var action = () => Coin.Flip(heads, tails);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(heads));
    }

    [TestMethod]
    public void Flip_WhenTailsIsNull_Throw()
    {
        //Arrange
        var heads = Dummy.Create<Action>();
        Action tails = null!;

        //Act
        var action = () => Coin.Flip(heads, tails);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(tails));
    }

    [TestMethod]
    public void Flip_Always_ExecuteEither()
    {
        //Arrange
        var headsChosen = false;
        var tailsChosen = false;

        Action heads = () => headsChosen = true;
        Action tails = () => tailsChosen = true;

        Coin.Flip(() => { }, () => { });

        //Act
        for (var i = 0; i < 20; i++)
            Coin.Flip(heads, tails);

        //Assert
        headsChosen.Should().BeTrue();
        tailsChosen.Should().BeTrue();
    }

    [TestMethod]
    public void FlipOne_WhenHeadsIsNull_Throw()
    {
        //Arrange
        Action heads = null!;

        //Act
        var action = () => Coin.Flip(heads);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(heads));
    }

    [TestMethod]
    public void FlipOne_WhenHeadsIsNotNull_ExecuteSometimes()
    {
        //Arrange
        var timesExecuted = 0;
        var totalTimes = 20;

        //Act
        for (var i = 0; i < totalTimes; i++)
            Coin.Flip(() => timesExecuted++);

        //Assert
        timesExecuted.Should().BeLessThan(totalTimes);
    }
}