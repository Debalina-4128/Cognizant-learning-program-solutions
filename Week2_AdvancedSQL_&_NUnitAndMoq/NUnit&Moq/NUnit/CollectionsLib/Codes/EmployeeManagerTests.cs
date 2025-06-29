using NUnit.Framework;
using CollectionsLib;
using System;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new EmployeeManager();
        }

        // Scenario 1: Ensure that there is no null value in the collection
        [Test]
        public void GetEmployees_ShouldNotContainNullEntries()
        {
            var employees = manager.GetEmployees();
            Assert.That(employees, Has.None.Null);
        }

        // Scenario 2: Verify whether employee with id 100 exists
        [Test]
        public void GetEmployees_ShouldContainEmployeeWithId100()
        {
            var employees = manager.GetEmployees();
            Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
        }

        // Scenario 3: Check uniqueness of employees by EmpId
        [Test]
        public void GetEmployees_EachEmployeeShouldHaveUniqueEmpId()
        {
            var employees = manager.GetEmployees();
            var uniqueEmpIds = employees.Select(e => e.EmpId).Distinct().Count();
            Assert.That(uniqueEmpIds, Is.EqualTo(employees.Count));
        }

        // Scenario 4: GetEmployees and GetEmployeesWhoJoinedInPreviousYears should return same set
        [Test]
        public void CompareEmployeeLists_ClassicalEqualityCheck()
        {
            var allEmployees = manager.GetEmployees();
            var joinedEmployees = manager.GetEmployeesWhoJoinedInPreviousYears();

            Assert.That(allEmployees.SequenceEqual(joinedEmployees), Is.True);
        }

        [Test]
        public void CompareEmployeeLists_UsingCollectionEquality()
        {
            var allEmployees = manager.GetEmployees();
            var joinedEmployees = manager.GetEmployeesWhoJoinedInPreviousYears();

            // Using Constraint model to compare collections
            Assert.That(joinedEmployees, Is.EquivalentTo(allEmployees));
        }
    }
}
