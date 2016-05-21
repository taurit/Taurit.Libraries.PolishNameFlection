# Name Flection in Polish language

## Usage example

    
```cs
IPolishNameFlectionHelper helper = new PolishNameFlectionHelper();

string nameInGenitive1 = helper.GetFirstName("Wiktoria Weronika", Case.Genitive);
// -> Wiktorii Weroniki

string nameInGenitive2 = helper.GetFirstName("Hugo", Case.Genitive);
// -> Hugona

string secondNameInGenitive1 = helper.GetFamilyName("Lewandowska", Gender.Female, Case.Genitive);
// -> Lewandowskiej

string secondNameInGenitive2 = helper.GetFamilyName("Lewandowski", Gender.Male, Case.Genitive);
// -> Lewandowskiego
```

Please note, that the only currently supported transformation is from **nominative form** to **genitive form**.

## About this project

This project consists of:
* a helper class to change a nominative form of someone's full name to a different grammar case
* a set of tests in xunit to cover a lot of regular cases and grammar exceptions
* a database of grammar exceptions to support library

## Target platforms

This project is distributed as a cross-platform class library written in .NET.

It attempts to have as little dependencies as possible and run on platforms compatible with **.NET Standard 1.0** contract set. **.NET Framework 4.0** and **.NET Framework 3.5** are also supported.
