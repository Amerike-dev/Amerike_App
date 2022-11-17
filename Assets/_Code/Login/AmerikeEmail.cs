using System;
using System.Collections.Generic;
using System.Security;

public class AmerikeEmail
{
    private HashSet<char> _emailHash = new HashSet<char>(" ?&^$#!()+-,:;<>’\'*");

    private string _dirtyEmail;
    private SecureString _cleanEmail;

    public string Email { set { _dirtyEmail = value; HandleNewMail(); } }
    public SecureString EmailSecure { get => _cleanEmail; }

    public AmerikeEmail(string mail)
    {
        HandleNewMail();
    }

    private void HandleNewMail()
    {
        string sanitizedMail = Sanitizer.SanitizeString(_emailHash,_dirtyEmail);
        if (ValidateMail(sanitizedMail)) _cleanEmail = SSBuilder.BuildSecureString(sanitizedMail);  
    }

    private bool ValidateMail(string email)
    {
        if (email.Contains("@amerike.edu.mx")) return true;
        else throw new NotSupportedException("Email does not contain expected domain");
    }
}
