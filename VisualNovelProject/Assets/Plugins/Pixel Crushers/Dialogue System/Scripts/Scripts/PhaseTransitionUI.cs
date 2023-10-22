using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PhaseTransitionUI : MonoBehaviour
{
    [SerializeField] TMP_Text phaseText;
    [SerializeField] BlackOverlay blackOverlay;
    [SerializeField] float fadeDuration = 1.5f; // Duration of the fade effect
    private void Awake()
    {
    }
    public void InitiateTransition()
    {
        blackOverlay.SetFade(true, 1f);
        StartCoroutine(FadeIn());


        phaseText.text = GameManager.Instance.GetCurrentPhase();
    }
    public void TransitionFadeOut()
    {
        blackOverlay.SetFade(false);
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1.5f);
        Color originalColor = phaseText.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Fading to fully visible

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            phaseText.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color originalColor = phaseText.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Fading to fully transparent

        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float blend = Mathf.Clamp01(currentTime / fadeDuration);
            phaseText.color = Color.Lerp(originalColor, targetColor, blend);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        TransitionFadeOut();
    }
}
