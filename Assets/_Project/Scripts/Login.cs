using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [Header("Login Fields")] 
    public string fieldUser;
    public string fieldPass;
    [Header("FeedbackConnection")] 
    public GameObject imageFeedback;
    public TextMeshProUGUI textDisplay;
   public void LogApp()
    {
        StartCoroutine(LoginUser(fieldUser, fieldPass));
    }
 IEnumerator LoginUser(string username, string password)
    {
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
                imageFeedback.SetActive(true);
                if (www.downloadHandler.text.Contains("Success"))
                {
                    StartCoroutine("ChangeScene");
                }
                else
                {
                    textDisplay.text = www.downloadHandler.text;
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

    IEnumerator ChangeScene()
    {
        textDisplay.text = "Logging . . . ";
        InfoSaver.infoSaver.username = fieldUser;
        Debug.Log(InfoSaver.infoSaver.username);
        yield return new WaitForSeconds(1f);
        imageFeedback.SetActive(false);
        SceneManager.LoadScene("ConfigureGamePlay");
    }
}