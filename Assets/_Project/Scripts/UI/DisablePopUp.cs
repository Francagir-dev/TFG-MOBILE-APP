using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePopUp : MonoBehaviour
{
    public Patients patient;



    public void DisablePopup()
    {
        transform.gameObject.SetActive(false);
        for (int i = 0; i < patient.itemsAdded.Count; i++)
        {
            patient.itemsAdded[i].GetComponent<Button>().interactable = true;
        }
    }

}