using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    RectTransform rectTransform;
    Button popupButton;
    bool visible = false;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        popupButton = GetComponent<Button>();
        popupButton.onClick.AddListener(PopupPaper);
    }
    public void PopupPaper()
    {
        if(visible)
        {
            visible = false;
            rectTransform.anchoredPosition = new Vector3(0, -470, 0);
        }
        else
        {
            visible = true;
            rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        }
    }
}
