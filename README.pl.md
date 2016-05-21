# Odmiana imion i nazwisk przez przypadki w języku polskim

## Przykład użycia
   
```cs
IPolishNameFlectionHelper helper = new PolishNameFlectionHelper();

string imieDopelniacz1 = helper.GetFirstName("Wiktoria Weronika", Case.Genitive);
// -> Wiktorii Weroniki

string imieDopelniacz2 = helper.GetFirstName("Hugo", Case.Genitive);
// -> Hugona

string nazwiskoDopelniacz1 = helper.GetFamilyName("Lewandowska", Gender.Female, Case.Genitive);
// -> Lewandowskiej

string nazwiskoDopelniacz2 = helper.GetFamilyName("Lewandowski", Gender.Male, Case.Genitive);
// -> Lewandowskiego
```

Obecnie jedyną wspieraną formą odmiany imion i nazwisk przez przypadki jest zmiana z **mianownika** na **dopełniacz**, jak w powyższych przykładach.

## O projekcie

Ten projekt składa się z:
* interfejsu i klasy pomocniczej, pozwalających **zmienić przypadek** gramatyczny zadanego imienia lub nazwiska,  
* zbioru testów w xunit. Zbiór danych testowych dostarczanych z testami zawiera zarówno popularne imiona i nazwiska jak i wyjątki od reguł.

## Kompatybilność

Ten projekt jest dystrybuowany jako biblioteka klas dla środowiska .NET. Zbudowaną wersję możesz znaleźć w repozytoriach pakietów **NuGet**. 

Biblioteka stara się bazować na jak najmniejszej liczbie zależności, co pozwala jej zachować kompatybilność z zestawem kontraktów **.NET Standard 1.0**. Wspierane sę również platformy **.NET Framework 4.0** oraz **.NET Framework 3.5**, a do czasu stabilizacji **.NET Core** również środowisko **DNX**.
