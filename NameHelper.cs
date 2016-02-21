using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using NameHelper.Polish;

namespace NameHelper.Polish
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class NameHelper
    {
        private readonly string _firstName;
        private readonly Gender _gender;
        private readonly string _secondName;

        public NameHelper(Gender gender, string firstName, string secondName = null)
        {
            this._gender = gender;
            this._secondName = secondName;
            this._firstName = firstName;
        }

        /// <summary>
        /// Sources for rules:
        /// * http://evacska.republika.pl/materialy/teoria/najpopularniejsze_imiona_w_polsce.htm - data for test
        /// </summary>
        /// <returns></returns>
        public string GetFirstNameInGenitiveForm()
        {
            var name = _firstName; // To make code more readable

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

        /// <summary>
        /// Sources for rules:
        /// * http://www.zsptychowo.pl/pdf/fleksja.pdf
        /// * http://www.proto.pl/PR/Pdf/porady_jezykowe/teoria_10_odcinek.pdf
        /// </summary>
        /// <returns></returns>
        public string GetSecondNameInGenitiveForm()
        {
            throw new NotImplementedException("todo"); // todo: implement
        }
    }
}