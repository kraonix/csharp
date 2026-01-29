using NUnit.Framework;
namespace Addition
{
    public class UnitTest1
    {
        [Test]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            Addition add = new Addition();

            // Act
            int actual = add.Add(1, 3);

            // Assert
            Assert.That(actual, Is.EqualTo(4));
        }
    }
}
