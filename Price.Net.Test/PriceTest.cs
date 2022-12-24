namespace Price.Net.Test;

public class PriceTest
{
     [Fact]
    public void CreatePrice_Set5M_ReturnExplicitMustBe5M()
    {
        var price = new Price(5M, "USD");
        var u = (decimal)price;
        Assert.Equal(5M, u);
    }

    [Fact]
    public void CreatePrice_PriceZero_ValueMustBeZero()
    {
        Assert.Equal(decimal.Zero, Price.Zero.Value);
    }

    [Fact]
    public void CreatePrice_PriceZero_CurrencyCodeMustBeUsd()
    {
        Assert.Equal("USD", Price.Zero.CurrencyCode);
    }

    [Fact]
    public void CreatePrice_ConstructorSetValueOne_PriceValueMustBeOne()
    {
        var p = new Price(1, "USD");
        Assert.Equal(1, p.Value);
    }

    [Fact]
    public void CreatePrice_ConstructorSetCurrencyCodeTry_CurrencyCodeMustBeTry()
    {
        var p = new Price(1, "TRY");
        Assert.Equal("TRY", p.CurrencyCode);
    }

    [Fact]
    public void CreateTwoDifferentPrice_TwoIsDifferentFromZero_PriceTotalMustBe2000()
    {
        //Arrange
        var leftPrice = new Price(1250M, "AUD");
        var rightPrice = new Price(750M, "AUD");

        //Act

        var totalPrice = leftPrice + rightPrice;

        //Assert

        Assert.Equal(new Price(leftPrice.Value + rightPrice.Value, leftPrice.CurrencyCode), totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceIsDifferentZero_PriceTotalMustBeEqualLeftPrice()
    {
        //Arrange
        var leftPrice = new Price(1250M, "AUD");
        var rightPrice = new Price(0, "AUD");

        //Act

        var totalPrice = leftPrice + rightPrice;

        //Assert

        Assert.Equal(leftPrice, totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceIsDifferentZero_PriceTotalMustBeEqualRightPrice()
    {
        //Arrange
        var leftPrice = new Price(0M, "AUD");
        var rightPrice = new Price(1250M, "AUD");

        //Act

        var totalPrice = leftPrice + rightPrice;

        //Assert

        Assert.Equal(rightPrice, totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_TwoIsDifferentFromZero_PriceSubtractionMustBe500()
    {
        //Arrange
        var leftPrice = new Price(1250M, "AUD");
        var rightPrice = new Price(750M, "AUD");

        //Act

        var totalPrice = leftPrice - rightPrice;

        //Assert

        Assert.Equal(new Price(leftPrice.Value - rightPrice.Value, leftPrice.CurrencyCode), totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceIsDifferentZero_PriceSubtractionMustBeEqualLeftPrice()
    {
        //Arrange
        var leftPrice = new Price(1250M, "AUD");
        var rightPrice = new Price(0, "AUD");

        //Act

        var totalPrice = leftPrice - rightPrice;

        //Assert

        Assert.Equal(leftPrice, totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceIsDifferentZero_PriceSubtractionMustBeEqualRightPrice()
    {
        //Arrange
        var leftPrice = new Price(0M, "AUD");
        var rightPrice = new Price(1250M, "AUD");

        //Act

        var totalPrice = leftPrice - rightPrice;

        //Assert

        Assert.Equal(new Price(rightPrice.Value * -1, rightPrice.CurrencyCode), totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceIsZero_PriceMultiplyMustBeZero()
    {
        //Arrange
        var leftPrice = new Price(0M, "AUD");
        var rightPrice = new Price(1250M, "AUD");

        //Act

        var totalPrice = leftPrice * rightPrice;

        //Assert

        Assert.Equal(Price.Zero, totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_RightPriceIsZero_PriceMultiplyMustBeZero()
    {
        //Arrange
        var leftPrice = new Price(1500M, "AUD");
        var rightPrice = new Price(0M, "AUD");

        //Act

        var totalPrice = leftPrice * rightPrice;

        //Assert

        Assert.Equal(Price.Zero, totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_TwoPricesDifferentFromZero_PriceMultiplyMustBeEqual5000()
    {
        //Arrange
        var leftPrice = new Price(1000M, "AUD");
        var rightPrice = new Price(5M, "AUD");

        //Act

        var totalPrice = leftPrice * rightPrice;

        //Assert

        Assert.Equal(new Price(leftPrice.Value * rightPrice.Value, leftPrice.CurrencyCode), totalPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_RightPriceZeroForDivision_ReturnDivideByZeroException()
    {
        //Arrange
        var leftPrice = new Price(1000M, "AUD");
        var rightPrice = new Price(0M, "AUD");

        //Assert

        Assert.Throws<DivideByZeroException>(() => leftPrice / rightPrice);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceZero_ReturnZeroPrice()
    {
        //Arrange
        var leftPrice = new Price(0M, "AUD");
        var rightPrice = new Price(5000M, "AUD");

        //Act
        var total = leftPrice / rightPrice;
        //Assert

        Assert.Equal(leftPrice, total);
    }

    [Fact]
    public void CreateTwoDifferentPrice_DividePrice_ReturnMustBeEqualDividedResult()
    {
        //Arrange
        var leftPrice = new Price(5M, "AUD");
        var rightPrice = new Price(1M, "AUD");

        //Act
        var total = leftPrice / rightPrice;
        //Assert

        Assert.Equal(new Price(leftPrice.Value / rightPrice.Value, leftPrice.CurrencyCode), total);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceSmallerThanRightPrice_ReturnMustBeTrue()
    {
        //Arrange
        var leftPrice = new Price(1M, "AUD");
        var rightPrice = new Price(5M, "AUD");

        //Act
        var result = leftPrice < rightPrice;
        //Assert

        Assert.True(result);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceGreaterThanRightPrice_ReturnMustBeTrue()
    {
        //Arrange
        var leftPrice = new Price(5M, "AUD");
        var rightPrice = new Price(1M, "AUD");

        //Act
        var result = leftPrice > rightPrice;
        //Assert

        Assert.True(result);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceEqualAndBiggerThanRightPrice_ReturnMustBeTrue()
    {
        //Arrange
        var leftPrice = new Price(5M, "AUD");
        var rightPrice = new Price(5M, "AUD");

        //Act
        var result = leftPrice >= rightPrice;
        //Assert

        Assert.True(result);
    }

    [Fact]
    public void CreateTwoDifferentPrice_LeftPriceEqualAndSmallerThanRightPrice_ReturnMustBeTrue()
    {
        //Arrange
        var leftPrice = new Price(5M, "AUD");
        var rightPrice = new Price(5M, "AUD");

        //Act
        var result = leftPrice <= rightPrice;
        //Assert

        Assert.True(result);
    }

    [Fact]
    public void CreateTwoDifferentPrice_Inequality_ReturnMustBeFalse()
    {
        //Arrange
        var leftPrice = new Price(5M, "AUD");
        var rightPrice = new Price(1M, "AUD");

        //Act
        var result = leftPrice != rightPrice;
        
        //Assert
        Assert.True(result);
    }
}