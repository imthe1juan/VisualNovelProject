using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOverlay : MonoBehaviour
{
    bool fadeIn = false;
    float fadeDelay = 1f;
    float fadeTime = 1f;
    [SerializeField] Image background; // Reference to the UI Image component
    public void SetFade(bool boolean, float fadeDelay = 1, float fadeTime = 1)
    {
        background.enabled = true;
        fadeIn = boolean;
        this.fadeDelay = fadeDelay;
        this.fadeTime = fadeTime;
        if (fadeIn) 
        {
            StartCoroutine(FadeInCor());
        }
        else
        {
            StartCoroutine(FadeOutCor());
        }
    }
    public void FadeIn() 
    {
        StartCoroutine(FadeInCor());
    }
    IEnumerator FadeInCor()
    {
        Color originalColor = background.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Fading to fully visible

        float currentTime = 0f;

        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeTime);
            background.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }
    }

    IEnumerator FadeOutCor()
    {
        yield return new WaitForSeconds(fadeDelay);
        Color originalColor = background.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Fading to fully transparent

        float currentTime = 0f;

        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeTime);
            background.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }

        background.color = new Color(0, 0, 0, 0f);
        background.enabled = false;
    }

}
