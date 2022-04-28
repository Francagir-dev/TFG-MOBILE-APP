using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public string fieldUser, fieldPass;
    public TextMeshProUGUI textDisplay;
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
                textDisplay.text = www.error;
            }
            else
            {
                if (www.downloadHandler.text.Contains("Sucess"))
                {
                    SceneManager.LoadScene("ConfigureGamePlay");
                }
            }

            textDisplay.text = www.downloadHandler.text;
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