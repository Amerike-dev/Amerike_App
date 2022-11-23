using System;
using System.Collections.Generic;
using System.Text;

public static class Sanitizer
{
    public static string SanitizeString(HashSet<char> hashSet, string dirtyString)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char character in dirtyString)
        {
            if (!hashSet.Contains(character))
            {
                stringBuilder.Append(character);
            }
            else throw new NotSupportedException("String is trying to use forbidden characters: " + character);
        }
        return stringBuilder.ToString();
    }

    public static string InverseSanitize(HashSet<char> hashSet, string dirtyString)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char character in dirtyString)
        {
            if (hashSet.Contains(character))
            {
                stringBuilder.Append(character);
            }
            else throw new NotSupportedException("String is trying to use forbidden characters: " + character);
        }
        return stringBuilder.ToString();
        }
    }

