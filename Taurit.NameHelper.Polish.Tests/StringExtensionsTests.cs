using System;
using Xunit;

namespace Taurit.NameHelper.Polish.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void AppendTextTests()
        {
            Assert.Equal("AB", "A".AppendText("B"));
            Assert.Equal("AB", "AB".AppendText(""));
            Assert.Equal("AB", "".AppendText("AB"));
            Assert.Equal("AB", ((string) null).AppendText("AB"));
            Assert.Equal("", ((string) null).AppendText(null));
            Assert.Equal("AB", "AB".AppendText(null));

            Assert.Equal("Test 1 ANSI", "Test 1 ".AppendText("ANSI"));
            Assert.Equal("Test 1 Unicode żźćńąśłęó", "Test 1 ".AppendText("Unicode żźćńąśłęó"));
        }

        [Fact]
        public void EndsWithRegexTests()
        {
            Assert.Equal(true, "ABC".EndsWithRegex("BC"));
            Assert.Equal(true, "ABC".EndsWithRegex("[CXYZ]"));
            Assert.Equal(true, "Stół".EndsWithRegex("ł"));
            Assert.Equal(true, "Stół".EndsWithRegex("[ł]"));
            Assert.Equal(true, "Stół".EndsWithRegex("[\\w]"));
            Assert.Equal(true, "Stół123".EndsWithRegex("[\\d]"));
            Assert.Equal(true, "ABC".EndsWithRegex("."));

            Assert.Equal(false, "Stół".EndsWithRegex("[\\d]"));
            Assert.Equal(false, "ABC".EndsWithRegex("[KXYZ]"));
            Assert.Equal(false, "ABC".EndsWithRegex("ABABC"));
            Assert.Equal(false, "Ł".EndsWithRegex("ł"));
            Assert.Equal(false, "".EndsWithRegex("."));
        }

        [Fact]
        public void RemoveNthLastCharacterTests()
        {
            Assert.Equal("Mart", "Marta".RemoveNthLastCharacter(0));
            Assert.Equal("Mara", "Marta".RemoveNthLastCharacter(1));
            Assert.Equal("Mata", "Marta".RemoveNthLastCharacter(2));
            Assert.Equal("Mrta", "Marta".RemoveNthLastCharacter(3));
            Assert.Equal("arta", "Marta".RemoveNthLastCharacter(4));
            Assert.NotNull(Record.Exception(() => "Marta".RemoveNthLastCharacter(5)));
            Assert.NotNull(Record.Exception(() => "Marta".RemoveNthLastCharacter(-1)));
        }

        [Fact]
        public void ReplaceEndingTests()
        {
            Assert.Equal("Stadion", "Stół".ReplaceEnding("ół", "adion"));
            Assert.Equal("Słońce", "Słoń".ReplaceEnding("", "ce"));
            Assert.Equal("Słońce", "Słota".ReplaceEnding("ota", "ońce"));
            Assert.Throws<ArgumentException>(() => "Słota".ReplaceEnding("x", "y"));
        }
    }
}