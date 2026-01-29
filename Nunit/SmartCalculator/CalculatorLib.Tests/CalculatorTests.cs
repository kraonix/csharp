using NUnit.Framework;
using CalculatorLib;

namespace CalculatorLib.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new Calculator();
    }

    [Test]
    public void Add_Works()
    {
        Assert.That(_calc.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ShouldThrow()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    [Test]
    public void SquareRoot_Negative_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => _calc.SquareRoot(-4));
    }

    [Test]
    public void Add_Overflow_ShouldThrow()
    {
        Assert.Throws<OverflowException>(() => _calc.Add(int.MaxValue, 1));
    }

    [TestCase("10", "20", 30)]
    [TestCase("5", "5", 10)]
    public void ParseAndAdd_ValidStrings(string a, string b, int expected)
    {
        Assert.That(_calc.ParseAndAdd(a, b), Is.EqualTo(expected));
    }

    [Test]
    public void ParseAndAdd_InvalidString_ShouldThrow()
    {
        Assert.Throws<FormatException>(() => _calc.ParseAndAdd("10", "abc"));
    }
}
