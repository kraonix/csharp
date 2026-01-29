using Moq;
using EmployeeApp.Core;
using System.Collections.Generic;

namespace EmployeeApp.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        [Test]
        public void GetEmployeeCount_ReturnsCorrectCount()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();

            mockRepo
                .Setup(r => r.GetAll())
                .Returns(new List<Employee>
                {
                    new Employee { Id = 1, Name = "Ravi" },
                    new Employee { Id = 2, Name = "Anu" }
                });

            var service = new EmployeeService(mockRepo.Object);

            // Act
            int count = service.GetEmployeeCount();

            // Assert
            Assert.That(count, Is.EqualTo(2));

        }
    }
}
