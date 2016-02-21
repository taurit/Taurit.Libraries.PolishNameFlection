using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NameHelper.Polish.Tests
{
    public class StringExtensionsTests
    {
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
    }
}
