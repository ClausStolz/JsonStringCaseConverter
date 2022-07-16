namespace JsonStringCaseConverter.Tests;

public class StringCaseExtensionTests
{
    [TestCase("TestIt", "test_it")]
    [TestCase("testTest", "test_test")]
    [TestCase("test_test", "test_test")]
    [TestCase("Test TestTest", "test test_test")]
    public void ToSnakeCaseTest(string source, string result)
    {
        Assert.That(source.ToSnakeCase(), Is.EqualTo(result));
    }
    
    [TestCase("TestIt", "TestIt")]
    [TestCase("testTest", "TestTest")]
    [TestCase("test_test", "TestTest")]
    [TestCase("test test_test", "Test TestTest")]
    public void ToPascalCaseTest(string source, string result)
    {
        Assert.That(source.ToPascalCase(), Is.EqualTo(result));
    }
    
    [TestCase("TestIt", "testIt")]
    [TestCase("testTest", "testTest")]
    [TestCase("test_test", "testTest")]
    [TestCase("Test test_test", "test testTest")]
    public void ToCamelCaseTest(string source, string result)
    {
        Assert.That(source.ToCamelCase(), Is.EqualTo(result));
    }
}