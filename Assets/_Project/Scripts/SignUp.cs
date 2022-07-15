using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SignUp : MonoBehaviour
{
    string userField;
    string passField;
    string confirmPassField;
    string emailField;
    public ChangeBetweenCanvas canvasChange;

   

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
        else
        {
            Debug.Log("No coinciden");
            passField = "";
        }
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
            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if(!www.downloadHandler.text.Contains("error"))
                    StartCoroutine(WaitAfterSign());
            }
        }
    }

    IEnumerator WaitAfterSign()
    {
        yield return new WaitForSeconds(0.6f);
        canvasChange.ResetInputFields();
        canvasChange.ChangeCanvas();
        
    }
    

}
