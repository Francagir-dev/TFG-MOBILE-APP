using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SavePatient : MonoBehaviour
{
    public string name, genre, phobia, localization;
    public int age, anxietyLvl;

    public TMP_Dropdown ageDropdown;
    public TMP_Dropdown genreDropdown;
    public TMP_Dropdown anxietyLvlDropdown;
    public void AddPatient()
    {
        StartCoroutine(SavePatientInfo(name, genre, age, anxietyLvl, phobia, localization));
    }

    IEnumerator SavePatientInfo(string name, string genre, int age, int anxietyLvl, string phobia, string localization)
    {
        WWWForm form = new WWWForm();
        form.AddField("patientName", name);
        form.AddField("patientGenre", genre);
        form.AddField("patientAge", age);
        form.AddField("patientPhobia", phobia);
        form.AddField("patientAnxietyLVL", anxietyLvl);
        form.AddField("patientLocation", localization);
        form.AddField("specialistID",InfoSaver.infoSaver.userID);

        using (UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP + "/PostPatient.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (!www.downloadHandler.text.Contains("error"))
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }
    }

    #region Functions Setting Values

    public void SetPatientName(string patientName)
    {
        name = patientName;
    }

    public void SetPatientAge(int value)
    {       
        age = int.Parse(ageDropdown.options[value].text);
    }

    public void SetPatientGenre(int value)
    {
      genre = genreDropdown.options[value].text;       
    }

    public void SetPatientAnxietyLvL(int value)
    {
        anxietyLvl = int.Parse(anxietyLvlDropdown.options[value].text);
    }

    public void SetPatientPhobia(string patientPhobia)
    {
        phobia = patientPhobia;
    }

    public void SetPatientLocalization(string patientLocalization)
    {
        localization = patientLocalization;
    }

    #endregion
}