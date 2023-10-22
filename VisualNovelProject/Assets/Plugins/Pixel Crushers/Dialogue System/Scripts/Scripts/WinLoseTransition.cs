using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinLoseTransition : MonoBehaviour
{
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text stateText;
    [SerializeField] BlackOverlay blackOverlay;
    [SerializeField] float fadeDuration = 1.5f; // Duration of the fade effect
    private void Awake()
    {
    }
    public void SetText(string descriptionText, string stateText, Color color) 
    {
        this.descriptionText.text = descriptionText;
        this.stateText.color = color;
        this.stateText.color = new Color(color.r, color.g, color.b, 0);

        this.stateText.text = stateText;

        InitiateTransition();
    }
    public void InitiateTransition()
    {
        blackOverlay.SetFade(true, 1f);
        StartCoroutine(FadeIn());
    }
    public void TransitionFadeOut()
    {
        blackOverlay.SetFade(false);
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        Color originalColor = descriptionText.color;
        Color originalColor2 = stateText.color;

        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Fading to fully visible
        Color targetColor2 = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 1f); // Fading to fully visible

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            descriptionText.color = Color.Lerp(originalColor, targetColor, blend);
            stateText.color = Color.Lerp(originalColor2, targetColor2, blend);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Color originalColor = descriptionText.color;
        Color originalColor2 = stateText.color;

        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Fading to fully transparent
        Color targetColor2 = new Color(originalColor2.r, originalColor2.g, originalColor2.b, 1f); // Fading to fully visible

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            descriptionText.color = Color.Lerp(originalColor, targetColor, blend);
            stateText.color = Color.Lerp(originalColor2, targetColor2, blend);
            yield return null;
        }
    }
}
