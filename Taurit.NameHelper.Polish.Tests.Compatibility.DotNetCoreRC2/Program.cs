using System;
using System.Diagnostics;

namespace Taurit.NameHelper.Polish.Tests.Compatibility.DotNetCoreRC2
{
    public class Program
    {
        /// <summary>
        ///     Simple program targeting .NET Core RC2 to test library combatilbility with .NET projects
        /// </summary>
        public static void Main(string[] args)
        {
            var testedName = "Adam";
            IPolishNameFlectionHelper helper = new PolishNameFlectionHelper();
            string modifiedName = helper.GetFirstName(testedName, Case.Genitive);

            Debug.Assert(modifiedName == "Adama");
            Console.WriteLine($"Name '{testedName}' was successfuly converted to '{modifiedName}' by the library.");
            Console.ReadKey();

            // Also, test whether code example from documentation compiles and runs correctly:
            CodeExample();

            Console.ReadKey();
        }

        /// <summary>
        /// Example of library usage, for use in Readme file
        /// </summary>
        private static void CodeExample()
        {
            IPolishNameFlectionHelper helper = new PolishNameFlectionHelper();

            string nameInGenitive1 = helper.GetFirstName("Wiktoria Weronika", Case.Genitive);
            // -> Wiktorii Weroniki

            string nameInGenitive2 = helper.GetFirstName("Hugo", Case.Genitive);
            // -> Hugona

            string secondNameInGenitive1 = helper.GetFamilyName("Lewandowska", Gender.Female, Case.Genitive);
            // -> Lewandowskiej

            string secondNameInGenitive2 = helper.GetFamilyName("Lewandowski", Gender.Male, Case.Genitive);
            // -> Lewandowskiego

        }
    }
}