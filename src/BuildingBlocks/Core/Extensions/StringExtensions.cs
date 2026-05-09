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
    public static bool IsNullEmptyOrWhiteSpace(this string? value) =>
        string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// remove all vocal from a given string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string RemoveVocals(this string value) => value.Remove("aeiouAEIOU");

    /// <summary>
    /// returns an string of a given length. If the string is shorter than the length it will return it
    /// as it is
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static string GetStringUpto(this string value, int maxLength)
    {
        if (value.Length <= maxLength)
            return value;
        return value.Substring(0, maxLength - 1);
    }

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
        var newVal = "";
        foreach (char ochar in oldChars)
        {
            newVal = value.Replace(ochar, newChar);
        }
        return newVal;
    }

    /// <summary>
    /// remove all entries in a string from provided chars
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldChars"></param>
    /// <returns></returns>
    public static string Remove(this string value, string oldChars)
    {
        var newVal = "";
        foreach (var ochar in oldChars)
        {
            newVal = value.Replace(ochar.ToString(), "");
        }
        return newVal;
    }

    public static string UpdateIfDifferent(this string? value, string referece)
    {
        if (string.IsNullOrEmpty(value))
            return referece;
        return value;
    }
}
