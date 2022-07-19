using System.Collections.Generic;
using UnityEngine;

public class InfoSaver : MonoBehaviour
{
    public static InfoSaver infoSaver; //Instance
    [Header("VARIABLES TO SAVE")] 
    [HideInInspector] public string username;
    [HideInInspector] public string userID;
    [HideInInspector] public List<int> infoPatients = new List<int>();

    private void Awake()
    {
        if (infoSaver == null)
        {
            DontDestroyOnLoad(gameObject);
            infoSaver = this;
        }
        else if (infoSaver != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveID(string ID)
    {
        userID = ID;
    }
}