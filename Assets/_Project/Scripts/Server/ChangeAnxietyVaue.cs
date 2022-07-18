using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChangeAnxietyVaue : MonoBehaviour
{
   [SerializeField] private Slider _sliderAnxiety;
   [SerializeField] private int anxietyLvl;


    public void ChangeValue()
    {
        anxietyLvl = (int)_sliderAnxiety.value;
        StartCoroutine(AnxietyLvl(anxietyLvl));
        StartCoroutine(GetAnxiety());
    }

    IEnumerator AnxietyLvl(int patientAnxiety)
    {
        WWWForm form = new WWWForm();
        form.AddField("PatientLvl", patientAnxiety);
        using (UnityWebRequest www = UnityWebRequest.Post(Constants.SERVER_IP+"/SessionCommunication.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
           
        }
    }
    IEnumerator GetAnxiety()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Get(Constants.SERVER_IP+"/SessionCommunication.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);
            }
        }
    }
    
}
