using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeBetweenCanvas : MonoBehaviour
{

   public GameObject canvasToHide;
   public GameObject canvasToShow;
   [Header("UI ELEMENTS")] 
   public TMP_InputField userInField;
   public TMP_InputField passwordInField;
   public TMP_InputField confirmPasswordInField;
   public TMP_InputField emailInField;



   public void ResetInputFields()
   {
      userInField.text = "";
      passwordInField.text = "";
      confirmPasswordInField.text = "";
      emailInField.text = "";
   }
   public void ChangeCanvas()
   {
      canvasToHide.SetActive(false);
      canvasToShow.SetActive(true);
   }
}
