using System;
using System.Collections;
using SimpleJSON;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Patients : MonoBehaviour
{
    private Action<string> _createPatientsCallback;
    public FillPatientInfo _patientInfo;
    [Header("Prefabs")]
    public GameObject patient1;
    public GameObject patient2;
    public GameObject parent;
    private void OnEnable()
    {
        _createPatientsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreatePatientsRoutine(jsonArrayString));
        };
        CreatePatients();
    }

    public void CreatePatients()
    {
        StartCoroutine(_patientInfo.GetPatientsID(InfoSaver.infoSaver.userID, _createPatientsCallback));
    }

    IEnumerator CreatePatientsRoutine(string jsonArrayString)
    {
        //Parse Json array as Array
      JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
     
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone= false;
            string patientID = jsonArray[i].AsObject["patientID"];
            JSONObject patientInfoJson = new JSONObject();
            
            //CallBack to get information from server
            Action<string> getPatientInfoCallBack = (patientInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(patientInfo) as JSONArray;
                patientInfoJson = tempArray[0].AsObject;
            };
            StartCoroutine(_patientInfo.GetPatients(patientID, getPatientInfoCallBack));
            //wait until callback is called
            yield return new WaitUntil(() => isDone);
            GameObject itemToInstantiate = null;
            GameObject item;
            //Instantiate ItemsPrefabs
            if (i == 0 || i % 2 == 0)
                itemToInstantiate = patient1;

            else
                itemToInstantiate = patient2;
            
            item = Instantiate(itemToInstantiate, Vector3.zero, quaternion.identity, parent.transform);
            
            //Fill information
            item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = patientInfoJson["name"];
            item.transform.Find("Age").GetComponent<TextMeshProUGUI>().text = patientInfoJson["age"];
            item.transform.Find("Genre_TXT").GetComponent<TextMeshProUGUI>().text = patientInfoJson["genre"];
            item.transform.Find("AnxietyLevel").GetComponent<TextMeshProUGUI>().text = patientInfoJson["anxietyLevel"];
            item.transform.Find("Phobia").GetComponent<TextMeshProUGUI>().text = patientInfoJson["phobia"];
        }
        
    }
}
