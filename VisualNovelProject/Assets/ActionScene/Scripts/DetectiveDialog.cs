using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveDialog : MonoBehaviour
{
    private string[] Dialog;
    private List<string> DialogList;

    private void Start()
    {
        
        DialogList = new List<string> 
        {
           "…",
           "It’s so quiet.\r\n",
           "...",
        };
    }
}
