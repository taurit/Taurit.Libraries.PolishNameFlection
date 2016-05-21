using System;
using System.Diagnostics;

namespace Taurit.NameHelper.Polish.Tests.Compatibility.DotNet40
{
    /// <summary>
    ///     Simple program targeting .NET 4.0 to test library combatilbility with .NET projects
    /// </summary>
    internal static class Program
    {
        private static void Main(string[] args)
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