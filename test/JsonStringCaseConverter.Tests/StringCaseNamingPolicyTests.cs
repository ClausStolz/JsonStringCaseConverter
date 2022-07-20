using System;
using System.Text.Json;
using NUnit.Framework;

namespace JsonStringCaseConverter.Tests
{
    public record TestData(string? Text, DateTime? DateTime, string[]? Array);

    public class StringCaseNamingPolicyTests
    {
        private TestData data => new("test",
            new DateTime(1996, 08, 25, 10, 44, 00, DateTimeKind.Utc),
            new[] { "first", "second" });

        [TestCase(
            StringCases.SnakeCase,
            @"{""text"":""test"",""date_time"":""1996-08-25T10:44:00Z"",""array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.CamelCase,
            @"{""text"":""test"",""dateTime"":""1996-08-25T10:44:00Z"",""array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.PascalCase,
            @"{""Text"":""test"",""DateTime"":""1996-08-25T10:44:00Z"",""Array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.ConstantCase,
            @"{""TEXT"":""test"",""DATE_TIME"":""1996-08-25T10:44:00Z"",""ARRAY"":[""first"",""second""]}")]
        public void SerializationTest(StringCases stringCase, string result)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new JsonStringCaseNamingPolicy(stringCase)
            });

            Assert.That(json, Is.EqualTo(result));
        }

        [TestCase(
            StringCases.SnakeCase,
            @"{""text"":""test"",""date_time"":""1996-08-25T10:44:00Z"",""array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.CamelCase,
            @"{""text"":""test"",""dateTime"":""1996-08-25T10:44:00Z"",""array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.PascalCase,
            @"{""Text"":""test"",""DateTime"":""1996-08-25T10:44:00Z"",""Array"":[""first"",""second""]}")]
        [TestCase(
            StringCases.ConstantCase,
            @"{""TEXT"":""test"",""DATE_TIME"":""1996-08-25T10:44:00Z"",""ARRAY"":[""first"",""second""]}")]
        public void DeserializationTest(StringCases stringCase, string value)
        {
            var obj = JsonSerializer.Deserialize<TestData>(value, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new JsonStringCaseNamingPolicy(stringCase)
            });

            Assert.That(obj, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(obj!.Text, Is.EqualTo(data.Text));
                Assert.That(obj!.DateTime, Is.EqualTo(data.DateTime));
                Assert.That(obj!.Array, Is.EqualTo(data.Array));
            });
        }
    }
}