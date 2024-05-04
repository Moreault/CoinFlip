namespace CoinFlip.Tests;

[TestClass]
public class BooleanFlipTests
{
    [TestMethod]
    public void Always_ReturnEitherTrueOrFalse()
    {
        //Arrange
        var results = new List<bool>();

        //Act
        for (var i = 0; i < 20; i++)
            results.Add(Coin.Flip());

        //Assert
        results.Should().Contain(false);
        results.Should().Contain(true);
    }
}