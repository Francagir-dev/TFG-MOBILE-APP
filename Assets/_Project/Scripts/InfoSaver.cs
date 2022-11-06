using System.Collections.Generic;
using UnityEngine;https://github.com/Francagir-dev/TFG-MOBILE-APP/blob/main/Assets/_Project/Scripts/InfoSaver.cs

public class InfoSaver : MonoBehaviour
{
    public static InfoSaver infoSaver; //Instance
    [Header("VARIABLES TO SAVE")] 
    [HideInInspector] public string username;
    [HideInInspector] public string userID;
    [HideInInspector] public List<int> infoPatients = new List<int>();

    private void Awake()
    {
        if (infoSaver == null)//There is no instance
        {
            DontDestroyOnLoad(gameObject);//Won't destroy when change scene
            infoSaver = this; //Assign instance
        }
        else if (infoSaver != this) //Uf exist
        {
            Destroy(gameObject); //Destroy this
        }
    }

    public void SaveID(string ID)
    {
        userID = ID;
    }
}
