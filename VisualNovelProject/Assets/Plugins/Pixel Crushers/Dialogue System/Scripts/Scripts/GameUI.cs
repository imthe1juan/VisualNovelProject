using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text interrogationText;
    [SerializeField] TMP_Text phaseText;

    public void UpdateText(int interoggationCurrentCount, string phaseName)
    {
        interrogationText.text = $"Interrogation: {interoggationCurrentCount}";
        phaseText.text = phaseName;
    }
    public void UpdateText(string text, string phaseName)
    {
        interrogationText.text = $"{text}";
        phaseText.text = phaseName;
    }
}
