using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FillPatientInfo : MonoBehaviour
{
    void OnEnable()
    {
       StartCoroutine(GetPatients(InfoSaver.infoSaver.userID));
    }

    IEnumerator GetPatients(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("patientID", userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://"+Constants.SERVER_IP+"/backendtfg/GetPatients.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                Debug.Log(jsonArray);
                //CallBack function
            }
        }
    }
}