using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using TMPro;
using UnityEngine;

public class CredentialsReader : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TMP_InputField _userTMP;
    [SerializeField] private TMP_InputField _passwordTMP;

    private SecureString _userMailSS = new SecureString();
    private SecureString _userPasswordSS = new SecureString();

    private HashSet<char> _emailHash = new HashSet<char> (" ?&^$#!()+-,:;<>’\'*");
    private HashSet<char> _passwordHash = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");

    private void Start()
    {
        ValidateDependencies();
    }

    private void ReadCredentials()
    {
        _userMailSS.Clear();
        _userPasswordSS.Clear();

        string userMail = _userTMP.text.ToString();
        string userPassword = _passwordTMP.text.ToString();

        userMail = SanitizeString(_emailHash, userMail);
        userPassword = SanitizeString(_passwordHash, userPassword);

        if(ValidateMail(userMail)) _userMailSS = BuildSecureString(_userMailSS, userMail);
        _userPasswordSS = BuildSecureString(_userPasswordSS, userPassword);
    }

    private SecureString BuildSecureString(SecureString secureString, string input)
    {
        if (secureString.Length > 0) throw new Exception("Secure string is not empty");
        if (input.Length == 0) throw new Exception("Input string is empty");

        foreach (char character in input)
        {
            secureString.AppendChar(character);
        }

        return secureString;
    }

    private bool ValidateMail(string email)
    {
        if (email.Contains("@amerike.edu.mx")) return true;
        else throw new NotSupportedException("Email does not contain expected domain");
    }

    private string SanitizeString(HashSet<char> hashSet, string dirtyString)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach(char character in dirtyString)
        {
            if (!hashSet.Contains(character))
            {
                stringBuilder.Append(character);
            }
            else throw new NotSupportedException("String is trying to use forbidden characters: " + character);
        }
        return stringBuilder.ToString();
    }

    private void ValidateDependencies()
    {
        if (_userTMP == null) throw new NullReferenceException("User input field is not referenced in the script");
        if (_passwordTMP == null) throw new NullReferenceException("User password field is not referenced in the script");
    }
}
