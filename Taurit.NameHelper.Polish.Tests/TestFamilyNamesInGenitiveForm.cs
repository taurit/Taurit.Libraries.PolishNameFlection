using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

// ReSharper disable MemberCanBePrivate.Global

namespace Taurit.NameHelper.Polish.Tests
{
    public class TestFamilyNamesInGenitiveForm
    {
        public static IEnumerable<object[]> KnownMaleFamilyNames => LoadKnownFamilyNames(Gender.Male);
        public static IEnumerable<object[]> KnownFemaleFamilyNames => LoadKnownFamilyNames(Gender.Female);

        [Theory]
        [MemberData(nameof(KnownMaleFamilyNames))]
        [Trait("Category", "Family Name - Males")]
        public void FamilyNameFormShouldChangeToGenitiveCorrectly_ForMales(string nominative, string genitive,
            Gender nameGender)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(genitive, nh.GetFamilyNameInGenitiveForm(nominative, nameGender));
        }

        [Theory]
        [MemberData(nameof(KnownFemaleFamilyNames))]
        [Trait("Category", "Family Name - Female")]
        public void FamilyNameFormShouldChangeToGenitiveCorrectly_ForFemales(string nominative, string genitive,
            Gender nameGender)
        {
            var nh = new PolishNameFlectionHelper();
            Assert.Equal(genitive, nh.GetFamilyNameInGenitiveForm(nominative, nameGender));
        }


        private static IEnumerable<object[]> LoadKnownFamilyNames(Gender nameGender)
        {
            string[] names = File.ReadAllLines("Data/KnownFamilyNames.csv", Encoding.UTF8);
            IEnumerable<string> namesWiithoutHeader = names.Skip(1);

            var pairs = new List<object[]>();

            foreach (string name in namesWiithoutHeader)
            {
                string[] nameArray = name.Split(';');

                string popularity = nameArray[0];
                string maleFamilyNameNominative = nameArray[1];
                string femaleFamilyNameNominative = nameArray[2];
                string maleFamilyNameGenitive = nameArray[3];
                string femaleFamilyNameGenitive = nameArray[4];

                if (!string.IsNullOrEmpty(maleFamilyNameGenitive))
                {
                    pairs.Add(new object[] {maleFamilyNameNominative, maleFamilyNameGenitive, Gender.Male});
                }

                if (!string.IsNullOrEmpty(femaleFamilyNameGenitive))
                {
                    pairs.Add(new object[] {femaleFamilyNameNominative, femaleFamilyNameGenitive, Gender.Female});
                }
            }

            return pairs.Where(x => (Gender) x[2] == nameGender);
        }
    }
}