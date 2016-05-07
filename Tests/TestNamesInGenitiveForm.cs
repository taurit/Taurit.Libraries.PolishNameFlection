using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

// ReSharper disable MemberCanBePrivate.Global

namespace Taurit.NameHelper.Polish.Tests
{
    public class TestNamesInGenitiveForm
    {
        public static IEnumerable<object[]> KnownCorrectDataForMales => GetDataForGender(Gender.Male);
        public static IEnumerable<object[]> KnownCorrectDataForFemales => GetDataForGender(Gender.Female);
        public static IEnumerable<object[]> KnownFemaleNames => GetMostPopularNames(Gender.Female);
        public static IEnumerable<object[]> KnownMaleNames => GetMostPopularNames(Gender.Male);

        /// <summary>
        ///     Tests GetFirstNameInGenitiveForm() for the most popular 50+ male names in Poland
        /// </summary>
        [Theory]
        [MemberData(nameof(KnownCorrectDataForMales))]
        [Trait("Category", "Male")]
        public void NameFormShouldChangeToGenitiveCorrectly_ForMales(string nominative, string genitive, Gender gender)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(genitive, nh.GetFirstNameInGenitiveForm(nominative));
        }

        /// <summary>
        ///     Tests GetFirstNameInGenitiveForm() for the most popular 50+ female names in Poland
        /// </summary>
        [Theory]
        [MemberData(nameof(KnownCorrectDataForFemales))]
        [Trait("Category", "Female")]
        public void NameFormShouldChangeToGenitiveCorrectly_ForFemales(string nominative, string genitive, Gender gender)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(genitive, nh.GetFirstNameInGenitiveForm(nominative));
        }

        /// <summary>
        ///     Loads reference data for test from a file
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        private static IEnumerable<object[]> GetDataForGender(Gender gender)
        {
            string genderCode = gender == Gender.Female ? "F" : "M";

            string[] names = File.ReadAllLines("Tests/Data/KnownNames.csv", Encoding.UTF8);
            foreach (string name in names)
            {
                string[] nameArray = name.Split(';');
                string nameNominative = nameArray[0];
                string nameGenitive = nameArray[1];
                string genderCodeInFile = nameArray[2];

                if (genderCodeInFile == genderCode)
                    yield return new object[] {nameNominative, nameGenitive, gender};
            }
        }

        private static IEnumerable<object[]> GetMostPopularNames(Gender gender)
        {
            string fileName = gender == Gender.Female
                ? "Tests/Data/PopularFemaleNamesNominative.csv"
                : "Tests/Data/PopularMaleNamesNominative.csv";

            string[] names = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string name in names)
            {
                yield return new object[] {name};
            }
        }


        [Theory]
        [MemberData(nameof(KnownFemaleNames))]
        [Trait("Category", "Female - Gender recognition")]
        public void GenderShouldBeRecognizedCorrectly_ForRegularFemaleNames(string firstName)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(Gender.Female, nh.RecognizeGender(firstName));
        }

        [Theory]
        [MemberData(nameof(KnownMaleNames))]
        [Trait("Category", "Male - Gender recognition")]
        public void GenderShouldBeRecognizedCorrectly_ForRegularMaleNames(string firstName)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(Gender.Male, nh.RecognizeGender(firstName));
        }

        [Fact]
        public void GenderShouldBeRecognizedCorrectly_ForNamesInExceptionList()
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(Gender.Female, nh.RecognizeGender("Beatrycze"));

            Assert.Equal(Gender.Male, nh.RecognizeGender("Barnaba"));
            Assert.Equal(Gender.Male, nh.RecognizeGender("Kuba"));
            Assert.Equal(Gender.Male, nh.RecognizeGender("Bonawentura"));
            Assert.Equal(Gender.Male, nh.RecognizeGender("Kosma"));
        }
    }
}