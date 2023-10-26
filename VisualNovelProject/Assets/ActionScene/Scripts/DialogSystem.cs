using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TMP_Text DialogTextUI;
    public string[] Dialog;

    private DetectiveDialog detectiveDialog;
    

    private int DialogNum;

    

    private void Start()
    {
        DialogTextUI.text = Dialog[DialogNum = 0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            nextDialog();
        }
    }

    private void nextDialog()
    {
        DialogNum = (DialogNum + 1) % Dialog.Length;

        DialogTextUI.text = Dialog[DialogNum];
    }
}
