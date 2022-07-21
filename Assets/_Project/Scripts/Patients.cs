using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Patients : MonoBehaviour
{
    private Action<string> _createPatientsCallback;
    
    [Header("Other references")] public FillPatientInfo _patientInfo;
    public GameObject canvasCode;
    private JSONArray jsonArray;
    private List<GameObject> itemsAdded = new List<GameObject>();
    [Header("Prefabs")] 
    public GameObject patient1;
    public GameObject patient2;
    public GameObject parent;
    [Header("Lists patients Info")]
    private List<Patient> patients = new List<Patient>();

   [SerializeField] private PostSession session;
    private void OnEnable()
    {
        _createPatientsCallback = (jsonArrayString) =>
        {
            if (jsonArrayString != null)
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
        jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        if (jsonArray == null) yield return  null;
        
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            string patientID = jsonArray[i].AsObject["patientID"];
            JSONObject patientInfoJson = new JSONObject();

            //CallBack to get information from server
            Action<string> getPatientInfoCallBack = (patientInfo) =>
            {
                isDone = true;
                if (patientInfo != null)
                {
                    JSONArray tempArray = JSON.Parse(patientInfo) as JSONArray;
                    patientInfoJson = tempArray[0].AsObject;
                }
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

            Patient patient =
                new Patient(int.Parse(patientInfoJson["ID"]),
                    patientInfoJson["name"],
                    int.Parse(patientInfoJson["age"]), patientInfoJson["genre"],
                    int.Parse(patientInfoJson["anxietyLevel"]),
                    patientInfoJson["phobia"], 
                    patientInfoJson["Location"]);
            
            itemsAdded.Add(item);
            patients.Add(patient);
            item.GetComponent<Button>().onClick.AddListener(delegate { ActivateCanvas(itemsAdded.IndexOf(item)); });
            
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < itemsAdded.Count; i++)
        {
            Destroy(itemsAdded[i]);
        }

        itemsAdded.Clear();
        InfoSaver.infoSaver.infoPatients.Clear();
    }

    public void ActivateCanvas(int value)
    {
        for (int i = 0; i < itemsAdded.Count; i++)
        {
            {
                itemsAdded[i].GetComponent<Button>().interactable = false;
            }
            canvasCode.SetActive(true);
        }

        Patient patient = patients[value];
        session.StartSavingSession(patient);
        
    }
}