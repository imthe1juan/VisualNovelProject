using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    RectTransform rectTransform;
    Button popupButton;
    [SerializeField] float popUpSpeed;
    bool visible = true;
    bool transitioning = false;
    float yTransform = -470;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        popupButton = GetComponent<Button>();
        popupButton.onClick.AddListener(PopupPaper);
    }
    private void Update()
    {
        if (transitioning) 
        {
            if (!visible) 
            {
                yTransform -= popUpSpeed * Time.deltaTime;
                if(yTransform <= -470) 
                {
                    transitioning = false;
                    yTransform = -470;
                    visible = true;
                }
                rectTransform.anchoredPosition = new Vector3(50, yTransform, 0);

            }
            else 
            {
                yTransform += popUpSpeed * Time.deltaTime;
                if (yTransform >= -150)
                {
                    transitioning = false;
                    yTransform = -150;
                    visible = false;
                }
                rectTransform.anchoredPosition = new Vector3(50, yTransform, 0);
            }
        }
    }
    public void PopupPaper()
    {
        transitioning = true;
    }
}
