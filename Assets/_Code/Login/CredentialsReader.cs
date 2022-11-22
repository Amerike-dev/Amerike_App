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

    private void Start()
    {
        ValidateDependencies();
    }

    public void LoginButton()
    {
        ReadCredentials();
    }
    private void ValidateDependencies()
    {
        if (_userTMP == null) throw new NullReferenceException("User input field is not referenced in the script");
        if (_passwordTMP == null) throw new NullReferenceException("User password field is not referenced in the script");
    }

    private void ReadCredentials()
    {
        _userMailSS.Clear();
        _userPasswordSS.Clear();

        string userMail = _userTMP.text.ToString();
        string userPassword = _passwordTMP.text.ToString();

        AmerikeEmail amerikeMail = new AmerikeEmail(userMail);
        AmerikePassword amerikePassword = new AmerikePassword(userPassword);

        PrintCredentials(amerikeMail.EmailSecure, amerikePassword.PasswordSecure);      
    }
 
    private void PrintCredentials(SecureString emailSecure, SecureString passwordSecure)
    {
        Debug.Log(SSBuilder.BuildUnsecureString(emailSecure).ToString());
        Debug.Log(SSBuilder.BuildUnsecureString(passwordSecure).ToString());
    }
}
