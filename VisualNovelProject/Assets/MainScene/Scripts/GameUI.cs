using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text interrogationText;
    [SerializeField] Image phaseImage;

    public void UpdateText(int interoggationCurrentCount, Sprite phaseImage)
    {
        interrogationText.text = $"Interrogation: {interoggationCurrentCount}";
        this.phaseImage.sprite = phaseImage;
    }
    public void UpdateImage(string text, Sprite phaseImage)
    {
        interrogationText.text = $"{text}";
        this.phaseImage.sprite = phaseImage;
    }
}
