using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public string fieldUser;
    public string fieldPass;

    [Header("FeedbackConnection")] public GameObject imageFeedback;
    public TextMeshProUGUI textDisplay;

    public void LogApp()
    {
        StartCoroutine(LoginUser(fieldUser, fieldPass));
    }

    IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        // form.AddField("loginPass", password);
         form.AddField("loginPass", EncryptPassword(password));
        using (UnityWebRequest www =
               UnityWebRequest.Post(Constants.SERVER_IP + "/loginApp.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
                textDisplay.text = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);


                switch (www.downloadHandler.text)
                {
                    case "Error 401":
                        textDisplay.text = "Wrong Password";
                        break;
                    case "Error 404":
                        textDisplay.text = "Username does not exist";
                        break;
                    default:
                        InfoSaver.infoSaver.SaveID(www.downloadHandler.text);
                        StartCoroutine(ChangeScene());
                        break;
                }
            }
        }
    }

    public void ChangeUsername(string usernameField)
    {
        fieldUser = usernameField;
    }

    public void ChangePassword(string passwordField)
    {
        fieldPass = passwordField;
    }

    IEnumerator ChangeScene()
    {
        textDisplay.text = "Logging . . . ";
        InfoSaver.infoSaver.username = fieldUser;
        yield return new WaitForSeconds(1f);
        imageFeedback.SetActive(false);
        SceneManager.LoadScene("ConfigureGamePlay");
    }

    public string EncryptPassword(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x =
            new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }

        return s.ToString();
    }
}