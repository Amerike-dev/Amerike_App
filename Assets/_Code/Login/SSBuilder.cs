using System;
using System.Security;

public static class SSBuilder
{
    public static SecureString BuildSecureString(string dirtyString)
    {
        SecureString secureString = new SecureString();
        if (dirtyString.Length == 0) throw new Exception("Input string is empty");

        foreach (char character in dirtyString)
        {
            secureString.AppendChar(character);
        }

        return secureString;
    }
}
