
using TMPro;
using UnityEngine;


public class CreateNewSession : MonoBehaviour
{

  
    [SerializeField] private TextMeshProUGUI codeTxt;


    public void ChangeText(string code)
    {
        codeTxt.text = code;
    }

}
