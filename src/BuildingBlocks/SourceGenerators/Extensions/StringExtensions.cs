using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Seagull.SourceGenerators.Extensions;

public static class StringExtensions
{
    private static readonly Regex _splitNameRegex = new Regex(@"[\W_]+");

	// Taken from https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
	private static readonly ISet<string> ReservedKeywords = new HashSet<string>
	{
		"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const",
		"continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern",
		"false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface",
		"internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
		"params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
		"sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof",
		"uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
	};

	private static readonly Dictionary<string, string> _csharpTypeAlias = new Dictionary<string, string>(16)
	{
		{ "System.Int16", "short" },
		{ "System.Int32", "int" },
		{ "System.Int64", "long" },
		{ "System.String", "string" },
		{ "System.Object", "object" },
		{ "System.Boolean", "bool" },
		{ "System.Void", "void" },
		{ "System.Char", "char" },
		{ "System.Byte", "byte" },
		{ "System.UInt16", "ushort" },
		{ "System.UInt32", "uint" },
		{ "System.UInt64", "ulong" },
		{ "System.SByte", "sbyte" },
		{ "System.Single", "float" },
		{ "System.Double", "double" },
		{ "System.Decimal", "decimal" },
		{ "Int16", "short" },
		{ "Int32", "int" },
		{ "Int64", "long" },
		{ "String", "string" },
		{ "Object", "object" },
		{ "Boolean", "bool" },
		{ "Void", "void" },
		{ "Char", "char" },
		{ "Byte", "byte" },
		{ "UInt16", "ushort" },
		{ "UInt32", "uint" },
		{ "UInt64", "ulong" },
		{ "SByte", "sbyte" },
		{ "Single", "float" },
		{ "Double", "double" },
		{ "Decimal", "decimal" }
	};

	/// <summary>
	/// cleans up provided name. It remove any common module or pattern class name
	/// like Repository, Service, etc. Also if the name starts with two uppercase letters
	/// and the first is a capital I it assumes is an interface and removes it.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="module"></param>
	/// <returns></returns>
	public static string CleanUp(this string value, string? module = null)
	{
		var modules = !string.IsNullOrEmpty(module)
			? new List<string>{ module! }
			: new List<string>{ "Repository", "Service" };

		if(char.IsUpper(value[0]) && char.IsUpper(value[1]) && value[0] == 'I')
		{
			value = value.Substring(1, value.Length -1);
		}
		return (
			from mod in modules
			where value.EndsWith(mod)
			select mod.Substring(value.Length - mod.Length)
		).First();
	}

	/// <summary>
	/// Lowercases the first character of a given string.
	/// </summary>
	/// <param name="s">The string whose first character to lowercase.</param>
	/// <returns>The string with its first character lowercased.</returns>
	public static string? Decapitalize(this string? s)
	{
		if (s is null || char.IsLower(s[0]))
		{
			return s;
		}

		return char.ToLower(s[0]) + s.Substring(1);
	}

	/// <summary>
	/// Uppercases the first character of a given string.
	/// </summary>
	/// <param name="s">The string whose first character to uppercase.</param>
	/// <returns>The string with its first character uppercased.</returns>
	public static string? Capitalize(this string? s)
	{
		if (s is null || char.IsUpper(s[0]))
		{
			return s;
		}

		return char.ToUpper(s[0]) + s.Substring(1);
	}

	/// <summary>
	/// Escapes a reserved keyword which should be used as an identifier.
	/// </summary>
	/// <param name="identifier">The identifier to be used.</param>
	/// <returns>A valid identifier.</returns>
	public static string EscapeReservedKeyword(this string identifier)
	{
		if (ReservedKeywords.Contains(identifier))
		{
			return "@" + identifier;
		}

		return identifier;
	}

	/// <summary>
	/// Ensures normal PascalCase for an identifier. (e.g. "_age" becomes "Age").
	/// </summary>
	/// <param name="identifier">The identifier to get the property name for.</param>
	/// <returns>A PascalCase identifier.</returns>
	public static string ToPascalCaseIdentifier(this string identifier)
	{
		if (identifier.StartsWith("_"))
		{
			identifier = identifier.Substring(1);
		}

		return identifier.Capitalize()!;
	}

	/// <summary>
	/// Transforms an identifier to camelCase. (e.g. "_myAge" -> "myAge", "MyAge" -> "myAge").
	/// </summary>
	/// <param name="identifier">The identifier to transform.</param>
	/// <returns>A camelCase identifier.</returns>
	public static string ToCamelCaseIdentifier(this string identifier)
	{
		if (identifier.StartsWith("_"))
		{
			return identifier.Substring(1).Decapitalize()!;
		}

		var decaptialized = identifier.Decapitalize()!;
		if (decaptialized == identifier)
		{
			return "new" + identifier.Capitalize();
		}

		return decaptialized;
	}

	/// <summary>
	/// Converts a string to use camelCase.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The to camel case. </returns>
	public static string ToCamelCase(this string value)
	{
		if (string.IsNullOrEmpty(value))
			return value;

		string output = ToPascalCase(value);
		if (output.Length > 2)
			return char.ToLower(output[0]) + output.Substring(1);

		return output.ToLower();
	}

	/// <summary>
	/// Converts a string to use PascalCase.
	/// </summary>
	/// <param name="value">Text to convert</param>
	/// <returns>The string</returns>
	public static string ToPascalCase(this string value)
	{
		return value.ToPascalCase(_splitNameRegex);
	}

	/// <summary>
	/// Converts a string to use PascalCase.
	/// </summary>
	/// <param name="value">Text to convert</param>
	/// <param name="splitRegex">Regular Expression to split words on.</param>
	/// <returns>The string</returns>
	public static string ToPascalCase(this string value, Regex splitRegex)
	{
		if (string.IsNullOrEmpty(value))
			return value;

		var mixedCase = value.IsMixedCase();
		var names = splitRegex.Split(value);
		var output = new StringBuilder();

		if (names.Length > 1)
		{
			foreach (string name in names)
			{
				if (name.Length > 1)
				{
					output.Append(char.ToUpper(name[0]));
					output.Append(mixedCase ? name.Substring(1) : name.Substring(1).ToLower());
				}
				else
				{
					output.Append(name);
				}
			}
		}
		else if (value.Length > 1)
		{
			output.Append(char.ToUpper(value[0]));
			output.Append(mixedCase ? value.Substring(1) : value.Substring(1).ToLower());
		}
		else
		{
			output.Append(value.ToUpper());
		}

		return output.ToString();
	}

	/// <summary>
	/// Does string contain both uppercase and lowercase characters?
	/// </summary>
	/// <param name="s">The value.</param>
	/// <returns>True if contain mixed case.</returns>
	public static bool IsMixedCase(this string s)
	{
		if (String.IsNullOrEmpty(s))
			return false;

		var containsUpper = s.Any(Char.IsUpper);
		var containsLower = s.Any(Char.IsLower);

		return containsLower && containsUpper;
	}

	/// <summary>
	///  returns the last part of a canonical class name,
	/// </summary>
	public static string LastPart(this string source, char separator = '.') =>
		source.Split(separator).Last();

	/// <summary>
	/// converts a given type name into an interface representation like:
	/// <b>MarketRepository</b> to <b>IMarketRepository</b>
	/// </summary>
	/// <param name="source"></param>
	/// <param name="separator"></param>
	/// <returns></returns>
	public static string AsInterface(this string source, char separator = '.')
	{
		var typeName = source.LastPart();
		return source.Replace(separator + typeName, "") + separator + "I" + typeName;
	}

	/// <summary>
	/// replace all coincidences of the given original value with
	/// the provided value
	/// </summary>
	/// <param name="val">string to replace values from</param>
	/// <param name="original">value to be replace</param>
	/// <param name="replacement">value to replace with</param>
	/// <returns></returns>
	public static string ReplaceAll(this string val, string original, string replacement)
	{
		StringBuilder sb = new StringBuilder(val);
		sb.Replace(original, replacement);

		return sb.ToString();
	}

	public static string ToTypeName(this string type)
	{
		if (type == "System.Xml.XmlDocument")
			type = "System.String";

		if (_csharpTypeAlias.TryGetValue(type, out string t))
			return t;

		// drop system from namespace
		string[] parts = type.Split('.');
		if (parts.Length == 2 && parts[0] == "System")
			return parts[1];

		return type;
	}

	public static (string? ns, string name) ToInject(this string type)
	{
		var typeName = type.LastPart();
		return (type.Replace("." + typeName, ""), typeName);
	}

	public static string SimpleClassName(this string source)
	{
		return source.EndsWith("Controller")
			? source.Substring(0, source.Length - 10)
			: source.EndsWith("Service")
				? source.Substring(0, source.Length - 7)
				: source.EndsWith("Repository")
					? source.Substring(0, source.Length - 10)
					: source;
	}

	public static bool IsNullEmptyOrWhiteSpace(this string? source) =>
		string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

	public static string PlaceSymbol(this string source, string optional = "", params string?[] value) =>
		value.Any(val => !val.IsNullEmptyOrWhiteSpace()) ? source : optional;

	/// <summary>
	/// Attempts to pluralize the specified text according to the rules of the English language.
	/// </summary>
	/// <remarks>
	/// This function attempts to pluralize as many words as practical by following these rules:
	/// <list type="bullet">
	///		<item><description>Words that don't follow any rules (e.g. "mouse" becomes "mice") are returned from a dictionary.</description></item>
	///		<item><description>Words that end with "y" (but not with a vowel preceding the y) are pluralized by replacing the "y" with "ies".</description></item>
	///		<item><description>Words that end with "us", "ss", "x", "ch" or "sh" are pluralized by adding "es" to the end of the text.</description></item>
	///		<item><description>Words that end with "f" or "fe" are pluralized by replacing the "f(e)" with "ves".</description></item>
	///	</list>
	/// </remarks>
	/// <param name="text">The text to pluralize.</param>
	/// <param name="number">If number is 1, the text is not pluralized; otherwise, the text is pluralized.</param>
	/// <returns>A string that consists of the text in its pluralized form.</returns>
	public static string Pluralize(this string text, int number = 2)
	{
		if (number == 1)
		{
			return text;
		}
		else
		{
			// Create a dictionary of exceptions that have to be checked first
			// This is very much not an exhaustive list!
			Dictionary<string, string> exceptions = new Dictionary<string, string>()
			{
				{ "man", "men" },
				{ "woman", "women" },
				{ "child", "children" },
				{ "tooth", "teeth" },
				{ "foot", "feet" },
				{ "mouse", "mice" },
				{ "belief", "beliefs" }
			};

			if (exceptions.ContainsKey(text.ToLowerInvariant()))
			{
				return exceptions[text.ToLowerInvariant()];
			}
			else if (text.EndsWith("y", StringComparison.OrdinalIgnoreCase) &&
			         !text.EndsWith("ay", StringComparison.OrdinalIgnoreCase) &&
			         !text.EndsWith("ey", StringComparison.OrdinalIgnoreCase) &&
			         !text.EndsWith("iy", StringComparison.OrdinalIgnoreCase) &&
			         !text.EndsWith("oy", StringComparison.OrdinalIgnoreCase) &&
			         !text.EndsWith("uy", StringComparison.OrdinalIgnoreCase))
			{
				return text.Substring(0, text.Length - 1) + "ies";
			}
			else if (text.EndsWith("us", StringComparison.InvariantCultureIgnoreCase))
			{
				// http://en.wikipedia.org/wiki/Plural_form_of_words_ending_in_-us
				return text + "es";
			}
			else if (text.EndsWith("ss", StringComparison.InvariantCultureIgnoreCase))
			{
				return text + "es";
			}
			else if (text.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
			{
				return text;
			}
			else if (text.EndsWith("x", StringComparison.InvariantCultureIgnoreCase) ||
			         text.EndsWith("ch", StringComparison.InvariantCultureIgnoreCase) ||
			         text.EndsWith("sh", StringComparison.InvariantCultureIgnoreCase))
			{
				return text + "es";
			}
			else if (text.EndsWith("f", StringComparison.InvariantCultureIgnoreCase) && text.Length > 1)
			{
				return text.Substring(0, text.Length - 1) + "ves";
			}
			else if (text.EndsWith("fe", StringComparison.InvariantCultureIgnoreCase) && text.Length > 2)
			{
				return text.Substring(0, text.Length - 2) + "ves";
			}
			else
			{
				return text + "s";
			}
		}
	}
}
