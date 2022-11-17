using System;
using System.Runtime.InteropServices;
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

    public static string BuildUnsecureString(SecureString cleanString)
    {
        IntPtr unsecureString = IntPtr.Zero;
        try
        {
            unsecureString = Marshal.SecureStringToGlobalAllocUnicode(cleanString);
            return Marshal.PtrToStringUni(unsecureString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unsecureString);
        }
    }
}
