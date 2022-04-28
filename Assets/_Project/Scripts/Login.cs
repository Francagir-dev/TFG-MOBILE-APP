using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public string fieldUser, fieldPass;

    public void LogApp()
    {
        StartCoroutine(LoginUser(fieldUser, fieldPass));
    }

  
    IEnumerator LoginUser(string username, string password)
    {
        Debug.Log(username +" "+password);
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/backendtfg/loginApp.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Sucess"))
                {
                    Debug.Log("Loading app");
                }
            }
        }
    }

    public void ChangeUsername(string usernameField)
    {
        fieldUser = usernameField;
        Debug.Log(fieldUser);
    }

    public void ChangePassword(string passwordField)
    {
        fieldPass = passwordField;
        Debug.Log(fieldPass);
    }
}