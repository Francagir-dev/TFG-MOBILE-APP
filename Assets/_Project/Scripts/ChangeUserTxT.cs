using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeUserTxT : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameTxT;

    private void Start()
    {
     if(InfoSaver.infoSaver.username!=null) usernameTxT.text = InfoSaver.infoSaver.username;
    }
}