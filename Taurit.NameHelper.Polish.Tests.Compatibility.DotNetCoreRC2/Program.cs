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
        }
    }
}