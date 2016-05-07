using System;
using System.Collections.Generic;

namespace Taurit.NameHelper.Polish
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public interface IPolishNameFlectionHelper
    {
        /// <summary>
        ///     Recognize gender of a name, based on grammar rules and exception list.
        /// </summary>
        /// <param name="firstName">First (given) name of a person.</param>
        /// <returns>Recognized gender of a person</returns>
        Gender RecognizeGender(string firstName);

        /// <summary>
        ///     Returns genitive form of a Polish first (given) name.
        ///     Supports the scenario where a person has more than one name (eg. "Paweł Łukasz" or "Anna Maria")
        /// </summary>
        /// <param name="firstNameNominative">
        ///     Nominative form of a name, eg. "Adam", "Paweł", "Ewa, "Anna". If a person uses more than one name, names can be
        ///     separated with space character.
        /// </param>
        /// <returns>Names in a genitive form separated with space character</returns>
        string GetFirstNameInGenitiveForm(string firstNameNominative);
    }

    public class PolishNameFlectionHelper : IPolishNameFlectionHelper
    {
        private readonly HashSet<string> _knownFemaleNames = new HashSet<string> {"Beatrycze"};

        private readonly HashSet<string> _knownMaleNames = new HashSet<string>
        {
            "Kuba",
            "Bonawentura",
            "Barnaba",
            "Kosma"
        };

        public Gender RecognizeGender(string firstName)
        {
            // Lookup exception list (with names that don't follow the grammar rules)
            if (_knownMaleNames.Contains(firstName))
                return Gender.Male;

            if (_knownFemaleNames.Contains(firstName))
                return Gender.Female;

            // If the name ends with "a", it's most likely woman's name
            var heuristicGender = firstName.EndsWith("a", StringComparison.OrdinalIgnoreCase)
                ? Gender.Female
                : Gender.Male;

            return heuristicGender;
        }

        public string GetFirstNameInGenitiveForm(string firstNameNominative)
        {
            string namesInGenitive = string.Empty;

            string allNames = firstNameNominative;
            string[] namesArray = allNames.Split(' ');
            foreach (string name in namesArray)
            {
                if (namesInGenitive != string.Empty)
                    namesInGenitive += " ";

                namesInGenitive += GetNameInGenitiveForm(name);
            }

            return namesInGenitive;
        }

        /// <summary>
        ///     Changes form of a single given name from nominative to genitive.
        /// </summary>
        /// <param name="name">name in nominative form</param>
        /// <returns>name in genitive form</returns>
        private string GetNameInGenitiveForm(string name)
        {
            // Paweł, Marek -> Pawła, Marka, ale już nie Zbigniew
            if (name.EndsWithRegex("e[krł]"))
                return name.RemoveNthLastCharacter(1).AppendText("a");

            // Jerzy -> Jerzego, Antoni -> Antoniego
            if (name.EndsWithRegex("[y]"))
                return name.RemoveNthLastCharacter(0).AppendText("ego");

            if (name.EndsWithRegex("[i]"))
                return name.AppendText("ego");

            // Beatrycze -> Beatrycze
            if (name.EndsWith("cze"))
                return name;

            // Bożena -> Bożeny, Danuta -> Danuty, ...
            if (name.EndsWithRegex("[ntr]a"))
                return name.RemoveNthLastCharacter(0).AppendText("y");

            // Maja -> Mai, Maya -> Mai
            if (name.EndsWithRegex("a[jy]a"))
                return name.RemoveNthLastCharacter(0).RemoveNthLastCharacter(0).AppendText("i");

            // Agnieszka -> Agnieszki, Mia -> Mii
            if (name.EndsWithRegex("[kijlgl]a"))
                return name.RemoveNthLastCharacter(0).AppendText("i");

            // Enya -> Enyi
            if (name.EndsWithRegex("[y]a"))
                return name.RemoveNthLastCharacter(0).AppendText("i");

            // Tomasz -> Tomasza, works for most male names
            if (!name.EndsWith("a")) // so it's most likely male's name
                return name.AppendText("a");

            // Ewa -> Ewy
            if (name.EndsWith("a", StringComparison.InvariantCulture))
                return name.ReplaceEnding("a", "y");

            // Fallback rule, useless
            return name;
        }
    }
}