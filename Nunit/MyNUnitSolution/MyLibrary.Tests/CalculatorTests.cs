using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

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
    public void All_Assertion_Examples()
    {
        // 1. Equality Assertions
        int sum = _calc.Add(2, 2);
        Assert.That(sum, Is.EqualTo(4));
        Assert.That(sum, Is.Not.EqualTo(5));

        // 2. String Assertions
        string msg = _calc.GetGreeting("Alice");
        Assert.That(msg, Does.Contain("Alice"));
        Assert.That(msg, Does.StartWith("Hello"));
        Assert.That(msg, Is.Not.Empty);

        // 3. Numeric Ranges & Precision
        double div = _calc.Divide(10, 3);
        Assert.That(div, Is.EqualTo(3.33).Within(0.01));

        int number = 10;
        Assert.That(number, Is.GreaterThan(5));
        Assert.That(number, Is.InRange(1, 100));

        // 4. Boolean & Nulls (no constants → analyzer-safe)
        bool flag = true;
        string? nothing = null;

        Assert.That(flag, Is.True);
        Assert.That(nothing, Is.Null);

        // 5. Collection Assertions
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Has.Exactly(3).Items);
        Assert.That(list, Contains.Item(2));
        Assert.That(list, Is.Unique);

        // 6. Exception Assertions
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    // 7. Parameterized Tests
    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    public void Add_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        int result = _calc.Add(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }
}
