using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient
{
    
    public int ID;
    public string name;
    public int age;
    public string genre;
    public int anxietyLvL;
    public string phobia;
    public string location;
    
    public Patient(int id, string name, int age, string genre, int anxietyLvL, string phobia, string location)
    {
        ID = id;
        this.name = name;
        this.age = age;
        this.genre = genre;
        this.anxietyLvL = anxietyLvL;
        this.phobia = phobia;
        this.location = location;
    }

   
 }
