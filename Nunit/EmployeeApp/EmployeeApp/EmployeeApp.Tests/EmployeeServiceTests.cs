using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using EmployeeApp.Core;
[TestFixture]
public class EmployeeServiceTests
{
	Mock<IEmployeeRepository> _mockRepo = null;


	[SetUp]
	public void SetUp()
	{
		_mockRepo = new Mock<IEmployeeRepository>();
	}

	[Test]

	public void GetAll_2()
	{
		List<Employee> employees = new List<Employee>();
		employees.Add(new Employee() { Id=2, Name="RRRRRRRRRRRRRRR", Salary=100 });
		employees.Add(new Employee() { Id=2, Name="RRRRRRRRRRRRRRR", Salary=100 });
		_mockRepo.Setup(o=>o.GetAll()).Returns(employees);
		var result = _mockRepo.Object.GetAll();
		Assert.That(result, Is.EqualTo(employees));
	}

	[Test]
	public void GetEmployeeCount_ReturnsCorrectCount()
	{
		// Arrange
		var mockRepo = new Mock<IEmployeeRepository>();
		mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
		{
			new Employee{Id=1, Name="Ravi"},
			new Employee{Id=2, Name="Anu"}
		});

		var service = new EmployeeService(mockRepo.Object);

		// Act
		int count = service.GetEmployeeCount();

		// Assert
		Assert.That(count,Is.EqualTo(2));
	}
}
