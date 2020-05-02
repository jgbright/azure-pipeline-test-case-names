using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace AzureTestCaseName
{
    public class TestInput
    {
        public string Value { get; set; }

        public override string ToString() => $@"Custom display string ""{Value}""";
    }

    public class UnitTest1
    {
        public UnitTest1(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; }

        public static IEnumerable<object[]> ObjectTestInputs => new object[][]
        {
            new object[] { new TestInput { Value = "one" } },
            new object[] { new TestInput { Value = "two" } },
            new object[] { new TestInput { Value = "three" } },
        };

        public static IEnumerable<object[]> SimpleTestInputs => new object[][]
        {
            new object[] { "one" },
            new object[] { "two" },
            new object[] { "three" },
        };

        [MemberData(nameof(ObjectTestInputs))]
        [Theory]
        public void Azure_DataDrivenTest_CustomObjectParameter(TestInput input)
        {
            Output.WriteLine($"input object: {JsonSerializer.Serialize(input)}");
        }

        [MemberData(nameof(SimpleTestInputs))]
        [Theory]
        public void Azure_DataDrivenTest_StringParameter(string input)
        {
            Output.WriteLine($"input object: {JsonSerializer.Serialize(input)}");
        }
    }
}
