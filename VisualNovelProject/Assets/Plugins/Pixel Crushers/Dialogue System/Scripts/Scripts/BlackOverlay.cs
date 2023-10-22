using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOverlay : MonoBehaviour
{
    bool fadeIn = false;
    [SerializeField] Image background; // Reference to the UI Image component
    public float fadeDuration = 1.5f; // Duration of the fade effect
    public void SetFade(bool boolean, float fadeDuration = 1.5f)
    {
        background.enabled = true;
        fadeIn = boolean;
        this.fadeDuration = fadeDuration;

        if (fadeIn) 
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        Color originalColor = background.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Fading to fully visible

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            background.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Color originalColor = background.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Fading to fully transparent

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            background.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }

        background.color = new Color(0, 0, 0, 0f);
        background.enabled = false;
    }

}
