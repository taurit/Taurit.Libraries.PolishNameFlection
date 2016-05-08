namespace Taurit.NameHelper.Polish
{
    /// <summary>
    ///     Cases in Polish language, as in https://en.wikipedia.org/wiki/Polish_grammar#Nouns
    /// </summary>
    public enum Case
    {
        /// <summary>
        ///     Mianownik (kto? co?)
        /// </summary>
        Nominative,

        /// <summary>
        ///     Biernik (kogo? co?)
        /// </summary>
        Accusative,

        /// <summary>
        ///     Dopełniacz (kogo? czego?)
        /// </summary>
        Genitive,

        /// <summary>
        ///     Celownik (komu? czemu?)
        /// </summary>
        Dative,

        /// <summary>
        ///     Wołacz
        /// </summary>
        Vocative,

        /// <summary>
        ///     Miejscownik (o kim? o czym?)
        /// </summary>
        Locative,

        /// <summary>
        ///     Narzędnik (z kim? z czym?)
        /// </summary>
        Instrumental
    }
}