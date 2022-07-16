using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewSession : MonoBehaviour
{

    string SessionID="";

 
    public void CreateNewSessionID()
    {
        for(int i = 0; i < 5; i++)
        {
            int nRandom = Random.Range(0, 10);
            SessionID += nRandom;
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
