using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TxtSlider : MonoBehaviour
{
   public TextMeshProUGUI infoSlider;
   public Slider slider;


   public void ChangeText()
   {
      infoSlider.text = slider.value.ToString();
   }


}
