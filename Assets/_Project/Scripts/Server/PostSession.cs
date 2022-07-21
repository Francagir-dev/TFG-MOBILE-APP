using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PostSession : MonoBehaviour
{
    private string sessionCode = "";
    public CreateNewSession CreateNewSession;
    public void StartSavingSession(Patient patient)
    {
        StartCoroutine(SaveSessionInfo( patient.phobia,  patient.anxietyLvL,  patient.ID));
    }

    IEnumerator SaveSessionInfo(string phobiaFaced, int anxietyLvLPatient, int patientID)
    {

            CreateNewSessionID();
            WWWForm form = new WWWForm();
            form.AddField("phobiaPatient", phobiaFaced);
            form.AddField("anxietyLvLPatient", anxietyLvLPatient);
            form.AddField("sessionCode", sessionCode);
            form.AddField("patientID", patientID);
            form.AddField("specialistID", InfoSaver.infoSaver.userID);
            CreateNewSession.ChangeText(sessionCode);

            using (UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP + "/PostSession.php", form))
            {
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    if (!www.downloadHandler.text.Contains("Error"))
                    {
                        Debug.Log(www.downloadHandler.text);
                    }
                }
            }
    }
    public void CreateNewSessionID()
    {
       
        for(int i = 0; i < 5; i++)
        {
            int nRandom = Random.Range(0, 10);
            sessionCode += nRandom;
        }
        Debug.Log(sessionCode);
        
    }
}
