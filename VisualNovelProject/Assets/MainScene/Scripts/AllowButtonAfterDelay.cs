using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllowButtonAfterDelay : MonoBehaviour
{
    [SerializeField] float delay;
    private void OnEnable()
    {
        GetComponent<Button>().interactable = false;
        Invoke(nameof(AllowButton),delay); // Make interactable after 0.5 seconds
    }

    void AllowButton()
    {
        GetComponent<Button>().interactable = true;
    }
}