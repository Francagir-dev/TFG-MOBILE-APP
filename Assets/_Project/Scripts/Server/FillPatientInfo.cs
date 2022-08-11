using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FillPatientInfo : MonoBehaviour
{
    public IEnumerator GetPatientsID(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("specialistID", userID);
        using (UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP + "/GetPatientsID.php", form))
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
                    string jsonArray = www.downloadHandler.text;
                    //CallBack function
                    callback(jsonArray);
                }
            }
        }
    }

    public IEnumerator GetPatients(string patientID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("patientID", patientID);
        using (UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP + "/GetPatients.php", form))
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
                    string jsonArray = www.downloadHandler.text;
                    //CallBack function
                    callback(jsonArray);
                }
            }
        }
    }
}