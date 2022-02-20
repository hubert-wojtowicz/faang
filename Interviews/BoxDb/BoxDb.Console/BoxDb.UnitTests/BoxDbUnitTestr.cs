using System.Collections.Generic;
using BoxDb.Contract;
using BoxDb.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace BoxDb.UnitTests
{
    public class Tests
    {
        private IBoxDb _boxDb;

        [SetUp]
        public void Setup()
        {
            _boxDb = new BoxDbImplementation();
        }

        [TestCaseSource(typeof(TestCases), nameof(TestCases.Cases))]
        public void HandleList_WhenFinish_OtputShouldBeAsExpected(TestCase testcase)
        {
            var actualArray = new List<string>();
            foreach (var operation in testcase.input)
            {
                var opRes = _boxDb.Handle(operation);
                if (!string.IsNullOrWhiteSpace(opRes))
                    actualArray.Add(opRes);
            }

            actualArray.Should().BeEquivalentTo(testcase.output);
        }
    }

    public class TestCases
    {
        public static TestCase[] Cases =
        {
            new TestCase()
            {
                input = new [] {"BEGIN", "SET a 10", "GET a", "BEGIN", "SET a 20", "GET a", "ROLLBACK", "GET a", "ROLLBACK", "GET a" },
                output = new [] {"10", "20", "10", "NULL"}
            },
            new TestCase()
            {
                input = new [] {"BEGIN", "SET a 10", "GET a", "BEGIN", "SET a 20", "GET a", "ROLLBACK", "GET a", "ROLLBACK", "GET a" },
                output = new [] {"10", "20", "10", "NULL"}
            }
        };
    }

    public struct TestCase
    {
        public string[] input;
        public string[] output;
    }
}