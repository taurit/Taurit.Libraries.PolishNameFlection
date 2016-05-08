using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Taurit.NameHelper.Polish.Tests
{
    
    public class TestUnsupportedCases
    {
        [Theory]
        [InlineData(Case.Accusative)]
        [InlineData(Case.Instrumental)]
        [InlineData(Case.Locative)]
        [InlineData(Case.Nominative)]
        [InlineData(Case.Vocative)]
        [InlineData(Case.Dative)]
        public void ChangeToUnsupportedCase_ReturnsClearException(Case testedCase)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Throws<NotSupportedException>(() => nh.GetFirstName("Adam", testedCase));
        }

        [Theory]
        [InlineData(Case.Genitive)]
        public void ChangeToSupportedCase_DoesNotThrow(Case testedCase)
        {
            var nh = new PolishNameFlectionHelper();
            nh.GetFirstName("Adam", testedCase);
        }

    }
}
