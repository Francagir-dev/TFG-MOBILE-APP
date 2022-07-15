using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillDropDown : MonoBehaviour
{
    public TMP_Dropdown ageDropdown;
    public TMP_Dropdown genreDropdown;
    public TMP_Dropdown anxietyLvl;

    public void FillDropdowns()
    {
        ageDropdown.ClearOptions();
        genreDropdown.ClearOptions();
        anxietyLvl.ClearOptions();
        
        ageDropdown.options.Add(new TMP_Dropdown.OptionData(" ")); 
        genreDropdown.options.Add(new TMP_Dropdown.OptionData(" "));
        anxietyLvl.options.Add(new TMP_Dropdown.OptionData(" "));
        
        for (int i = 16; i < 101; i++)
        {
            ageDropdown.options.Add(new TMP_Dropdown.OptionData(i + ""));
        }

        genreDropdown.options.Add(new TMP_Dropdown.OptionData("Male"));
        genreDropdown.options.Add(new TMP_Dropdown.OptionData("Female"));
        genreDropdown.options.Add(new TMP_Dropdown.OptionData("I prefer not to answer"));
        
        for (int i = 1; i < 6; i++)
        {
            anxietyLvl.options.Add(new TMP_Dropdown.OptionData(i + ""));
        }
    }

    private void OnEnable()
    {
        FillDropdowns();
    }
}