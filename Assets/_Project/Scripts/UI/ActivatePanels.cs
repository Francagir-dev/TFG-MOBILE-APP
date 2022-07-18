using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanels : MonoBehaviour
{
      
    public List<GameObject> panels = new List<GameObject>();
    GameObject activePanel;
    private void Awake()
    {
        activePanel = panels[0];
    }
    public void ActiveDisablePanel(int panelToActivate)
    {
        activePanel.SetActive(false);
        activePanel = panels[panelToActivate];
        activePanel.SetActive(true);

    }



}
