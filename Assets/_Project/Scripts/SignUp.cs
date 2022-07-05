using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SignUp : MonoBehaviour
{
    [Header("Login Fields")] 
    public string userField;
    public string passField;
    public string confirmPassField;
    public string emailField;


    public void SignUpUserBTN()
    {
        StartCoroutine(SignUpUser(userField, passField, emailField));
    }
    public void ChangeUsername(string usernameField)
    {
        userField = usernameField;
    }
    public void ChangePassword(string passwordField)
    {
        passField = passwordField;
    } 
    public void ChangeConfirmPassword(string confirmPasswordField)
    {
        confirmPassField = confirmPasswordField;
    }
    public void ChangeEmail(string emailPasswordField)
    {
        emailField = emailPasswordField;
    }

    public void CheckPasswords()
    {
        if(passField.Equals(confirmPassField))  Debug.Log("Coinciden");
        else  Debug.Log("No Coinciden");
    }

    public string EncryptPassword(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    IEnumerator SignUpUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("signUpUser", username);
        form.AddField("signUpPass", EncryptPassword(password));
        form.AddField("signUpMail", email);
        using(UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP+"/SignUp.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }


}
