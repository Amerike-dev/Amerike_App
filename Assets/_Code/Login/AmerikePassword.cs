using System.Collections.Generic;
using System.Security;

public class AmerikePassword
{
    private HashSet<char> _passwordHash = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");

    private string _dirtyPassword;
    private SecureString _cleanPassword;

    public string Password { set { _dirtyPassword = value; HandleNewPassword(); } }
    public SecureString PasswordSecure { get => _cleanPassword; }

    public AmerikePassword(string password)
    {
        Password = password;
    }

    private void HandleNewPassword()
    {
        string sanitizedPassword = Sanitizer.SanitizeString(_passwordHash,_dirtyPassword);
        _cleanPassword = SSBuilder.BuildSecureString(sanitizedPassword);
    }
}
