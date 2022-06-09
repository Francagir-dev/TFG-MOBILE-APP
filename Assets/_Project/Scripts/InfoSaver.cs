using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSaver : MonoBehaviour
{
    public static InfoSaver infoSaver; //Instance
    [Header("VARIABLES TO SAVE")]
    public string username;
    public string userID;

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
}