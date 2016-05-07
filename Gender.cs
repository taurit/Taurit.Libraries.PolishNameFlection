namespace Taurit.NameHelper.Polish
{
    /// <summary>
    ///     Gender might be used to chose a proper rule when there are doubts how to change the form of a word.
    ///     While in case of first (given) names the rules do not depend on gender, in case of second (family) names
    ///     this hint might lead to better results.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        ///     In situation where gender is not known, this value might be passed.
        /// </summary>
        Unknown = 0,
        Female = 1,
        Male = 2
    }
}