using MasGlobal.Business.Entities;
using MasGlobal.Business.Interfaces;
using MasGlobal.DataAccess.Interfaces;
using MasGlobal.DataAccess.Interfaces.Dtos;
using MasGlobal.Insfrastucture.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Business.UnitTests
{
    [TestFixture]
    public class EmployeeBusinessTest
    {
        private Mock<IEmployeesRepository> employeesRepositoryMock;
        private Mock<IMapper> mapperMock;
        private IEmployeeBusiness employeeBusiness;

        [SetUp]
        public void SetUp()
        {
            employeesRepositoryMock = new Mock<IEmployeesRepository>();
            mapperMock = new Mock<IMapper>();
            employeeBusiness = new EmployeeBusiness(employeesRepositoryMock.Object, mapperMock.Object);
        }

        [Test]
        public void GetByIdAsync_WhenThereIsNoData_ReturnsNull()
        {
            var emptyList = Task.FromResult(new List<EmployeeDto>().AsEnumerable());
            employeesRepositoryMock.Setup(x => x.GetAllAsync()).Returns(emptyList);

            var result = employeeBusiness.GetByIdAsync(1).Result;

            Assert.IsNull(result);
        }

        [Test]
        public void GetByIdAsync_WhenThereIsData_ReturnsValidEmployee()
        {
            var employees = Task.FromResult(GetFakeEmployeeDto().AsEnumerable());
            employeesRepositoryMock.Setup(x => x.GetAllAsync()).Returns(employees);
            mapperMock.SetupSequence(x => x.MapFromDtoToEntity(It.IsAny<EmployeeDto>()))
                .Returns(GetFakeEmployeeEntity()[0])
                .Returns(GetFakeEmployeeEntity()[1]);
            var result = employeeBusiness.GetByIdAsync(1).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name == "Andrea");
        }

        [Test]
        public void GetByIdAsync_WhenContractTypeIsHourlyBased_ReturnsValidAnualSalary()
        {
            var employees = Task.FromResult(GetFakeEmployeeDto().AsEnumerable());
            employeesRepositoryMock.Setup(x => x.GetAllAsync()).Returns(employees);
            mapperMock.SetupSequence(x => x.MapFromDtoToEntity(It.IsAny<EmployeeDto>()))
                .Returns(GetFakeEmployeeEntity()[0])
                .Returns(GetFakeEmployeeEntity()[1]);
            var result = employeeBusiness.GetByIdAsync(1).Result;

            var expectedAnualSalary = 120 * result.HourlySalary * 12;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAnualSalary, result.CalculatedAnnualSalary);
        }

        [Test]
        public void GetByIdAsync_WhenContractTypeIsMonthtlyBased_ReturnsValidAnualSalary()
        {
            var employees = Task.FromResult(GetFakeEmployeeDto().AsEnumerable());
            employeesRepositoryMock.Setup(x => x.GetAllAsync()).Returns(employees);
            mapperMock.SetupSequence(x => x.MapFromDtoToEntity(It.IsAny<EmployeeDto>()))
                .Returns(GetFakeEmployeeEntity()[0])
                .Returns(GetFakeEmployeeEntity()[1]);
            var result = employeeBusiness.GetByIdAsync(2).Result;

            var expectedAnualSalary = result.MonthlySalary * 12;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAnualSalary, result.CalculatedAnnualSalary);
        }

        private List<EmployeeDto> GetFakeEmployeeDto()
        {
            var employees = new List<EmployeeDto>();
            employees.Add(new EmployeeDto { Id = 1, Name = "Andrea", ContractTypeName = "HourlySalaryEmployee", RoleId = 1, RoleName = "Administrator", RoleDescription = null, HourlySalary = 15, MonthlySalary = 2200 });
            employees.Add(new EmployeeDto { Id = 2, Name = "Alex", ContractTypeName = "MonthlySalaryEmployee", RoleId = 2, RoleName = "Contractor", RoleDescription = null, HourlySalary = 35, MonthlySalary = 4500 });

            return employees;
        }

        private List<EmployeeEntity> GetFakeEmployeeEntity()
        {
            var employees = new List<EmployeeEntity>();
            employees.Add(new EmployeeEntity { Id = 1, Name = "Andrea", ContractTypeName = "HourlySalaryEmployee", RoleId = 1, RoleName = "Administrator", RoleDescription = null, HourlySalary = 15, MonthlySalary = 2200 });
            employees.Add(new EmployeeEntity { Id = 2, Name = "Alex", ContractTypeName = "MonthlySalaryEmployee", RoleId = 2, RoleName = "Contractor", RoleDescription = null, HourlySalary = 35, MonthlySalary = 4500 });

            return employees;
        }
    }
}
