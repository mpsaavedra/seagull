using System;

namespace Seagull.Extensions;

/// <summary>
/// string related extensions
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// returns true if value is null, empty or white space
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullEmptyOrWhiteSpace(this string value) =>
        string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// remove all vocal from a given string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string RemoveVocals(this string value) => value.Remove("aeiouAEIOU");

    /// <summary>
    /// replace all entries in a string from the old chars to the newly provded
    /// char 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldChars"></param>
    /// <param name="newChar"></param>
    /// <returns></returns>
    public static string Replace(this string value, string oldChars, char newChar)
    {
        foreach(char ochar in oldChars)
        {
            value.Replace(ochar, newChar);
        }
        return value;
    }

    /// <summary>
    /// remove all entries in a string from provided chars
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldChars"></param>
    /// <returns></returns>
    public static string Remove(this string value, string oldChars)
    {
        foreach(char ochar in oldChars)
        {
            value.Remove(ochar);
        }
        return value;
    }

    public static string UpdateIfDifferent(this string? value, string referece)
    {
        if(string.IsNullOrEmpty(value))
            return referece;
        return value;
    }
}
