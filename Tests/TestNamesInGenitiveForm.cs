using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
// ReSharper disable MemberCanBePrivate.Global

namespace NameHelper.Polish.Tests
{
    public class TestNamesInGenitiveForm
    {
        /// <summary>
        /// Tests GetFirstNameInGenitiveForm() for the most popular 50+ male names in Poland
        /// </summary>
        [Theory]
        [MemberData(nameof(KnownCorrectDataForMales))]
        [Trait("Category", "Male")]
        public void TestNameFlectionForMales(string nominative, string genitive, Gender gender)
        {
            NameHelper nh = new NameHelper(gender, nominative);
            Assert.Equal(genitive, nh.GetFirstNameInGenitiveForm());
        }

        /// <summary>
        /// Tests GetFirstNameInGenitiveForm() for the most popular 50+ female names in Poland
        /// </summary>
        [Theory]
        [MemberData(nameof(KnownCorrectDataForFemales))]
        [Trait("Category", "Female")]
        public void TestNameFlectionForFemales(string nominative, string genitive, Gender gender)
        {
            NameHelper nh = new NameHelper(gender, nominative);
            Assert.Equal(genitive, nh.GetFirstNameInGenitiveForm());
        }


        public static IEnumerable<object[]> KnownCorrectDataForMales => GetDataForGender(Gender.Male);
        public static IEnumerable<object[]> KnownCorrectDataForFemales => GetDataForGender(Gender.Female);

        /// <summary>
        /// Loads reference data for test from a file
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        private static IEnumerable<object[]> GetDataForGender(Gender gender)
        {
            string genderCode = gender == Gender.Female ? "F" : "M";

            string[] names = File.ReadAllLines("KnownNames.csv", Encoding.UTF8);
            foreach (var name in names)
            {
                string[] nameArray = name.Split(';');
                string nameNominative = nameArray[0];
                string nameGenitive = nameArray[1];
                string genderCodeInFile = nameArray[2];

                if (genderCodeInFile == genderCode)
                    yield return new object[] {nameNominative, nameGenitive, gender};
            }
        }
    }
}