using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewSession : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI codeTxt;


    private void OnEnable()
    {
        CreateNewSessionID();
    }

    public void CreateNewSessionID()
    {
        string SessionID = "";
        for(int i = 0; i < 5; i++)
        {
            int nRandom = Random.Range(0, 10);
            SessionID += nRandom;
        }

        codeTxt.text = SessionID;
    }

}
