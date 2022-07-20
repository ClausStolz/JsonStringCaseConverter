using NUnit.Framework;

namespace JsonStringCaseConverter.Tests
{
    public class StringCaseExtensionTests
    {
        [TestCase("", "")]
        [TestCase("ID", "id")]
        [TestCase("IDTest", "id_test")]
        [TestCase("TestIt", "test_it")]
        [TestCase("testTest", "test_test")]
        [TestCase("test_test", "test_test")]
        [TestCase("Test TestTest", "test test_test")]
        [TestCase("Test TestTEST", "test test_test")]
        public void ToSnakeCaseTest(string source, string result)
        {
            Assert.That(source.ToSnakeCase(), Is.EqualTo(result));
        }
        
        [TestCase("", "")]
        [TestCase("ID", "ID")]
        [TestCase("IDTest", "ID_TEST")]
        [TestCase("TestIt", "TEST_IT")]
        [TestCase("testTest", "TEST_TEST")]
        [TestCase("test_test", "TEST_TEST")]
        [TestCase("Test TestTest", "TEST TEST_TEST")]
        [TestCase("Test TestTEST", "TEST TEST_TEST")]
        public void ToConstantCaseTest(string source, string result)
        {
            Assert.That(source.ToConstantCase(), Is.EqualTo(result));
        }
        
        [TestCase("", "")]
        [TestCase("ID", "Id")]
        [TestCase("IDTest", "IdTest")]
        [TestCase("TestIt", "TestIt")]
        [TestCase("testTest", "TestTest")]
        [TestCase("test_test", "TestTest")]
        [TestCase("test test_test", "Test TestTest")]
        [TestCase("Test TestTEST", "Test TestTest")]
        public void ToPascalCaseWithoutSavingUpperCaseTest(string source, string result)
        {
            Assert.That(source.ToPascalCase(), Is.EqualTo(result));
        }

        [TestCase("", "")]
        [TestCase("ID", "ID")]
        [TestCase("IDTest", "IDTest")]
        [TestCase("TestIt", "TestIt")]
        [TestCase("testTest", "TestTest")]
        [TestCase("test_test", "TestTest")]
        [TestCase("test test_test", "Test TestTest")]
        [TestCase("Test TestTEST", "Test TestTEST")]
        public void ToPascalCaseWithSavingUpperCaseTest(string source, string result)
        {
            Assert.That(source.ToPascalCase(saveUpperCase: true), Is.EqualTo(result));
        }

        // [TestCase("", "")]
        // [TestCase("ID", "id")]
        // [TestCase("IDTest", "idTest")]
        // [TestCase("TestIt", "testIt")]
        // [TestCase("testTest", "testTest")]
        // [TestCase("test_test", "testTest")]
        // [TestCase("Test test_test", "test testTest")]
        [TestCase("Test TestTEST", "test testTest")]
        public void ToCamelCaseWithoutSavingUpperCaseTest(string source, string result)
        {
            Assert.That(source.ToCamelCase(), Is.EqualTo(result));
        }

        [TestCase("", "")]
        [TestCase("ID", "ID")]
        [TestCase("IDTest", "IDTest")]
        [TestCase("TestIt", "testIt")]
        [TestCase("testTest", "testTest")]
        [TestCase("test_test", "testTest")]
        [TestCase("Test test_test", "test testTest")]
        [TestCase("Test TestTEST", "test testTEST")]
        public void ToCamelCaseWithSavingUpperCaseTest(string source, string result)
        {
            Assert.That(source.ToCamelCase(saveUpperCase: true), Is.EqualTo(result));
        }

        [TestCase("", new[] { "" })]
        [TestCase("ID", new[] { "ID" })]
        [TestCase("IDTest", new[] { "ID", "Test" })]
        [TestCase("TestIt", new[] { "Test", "It" })]
        [TestCase("testTest", new[] { "test", "Test" })]
        [TestCase("test_test", new[] { "test", "test" })]
        [TestCase("Test test_test", new[] { "Test", "test", "test" })]
        [TestCase("Test TEST_testTEST", new[] { "Test", "TEST", "test", "TEST" })]
        public void SplitForWordsTest(string source, string[] result)
        {
            Assert.That(source.SplitForWords(), Is.EqualTo(result));
        }
    }
}