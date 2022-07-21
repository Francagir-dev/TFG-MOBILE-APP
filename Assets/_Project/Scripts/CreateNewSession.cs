using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewSession : MonoBehaviour
{

  
    [SerializeField] private TextMeshProUGUI codeTxt;


    public void ChangeText(string code)
    {
        codeTxt.text = code;
    }

}
