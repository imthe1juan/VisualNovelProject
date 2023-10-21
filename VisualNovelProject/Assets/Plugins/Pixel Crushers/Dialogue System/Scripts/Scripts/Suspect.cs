using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class Suspect : MonoBehaviour
{
    [SerializeField] int id;
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Interrogate);
    }

    void Interrogate()
    {
        GameManager.Instance.Interrogate();
        Debug.Log("Start");
        DialogueManager.StartConversation($"New Conversation {id}", transform, transform);      
    }
}
