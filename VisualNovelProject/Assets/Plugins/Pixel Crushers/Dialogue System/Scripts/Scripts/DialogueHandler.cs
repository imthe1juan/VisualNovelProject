using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] GameObject[] dialogueManagers;
    public void NextDialogueManager(int dialogueID) 
    {
        for (int i = 0; i < dialogueManagers.Length - 1; i++)
        {
            dialogueManagers[i].SetActive(false);
        }
        dialogueManagers[dialogueID].SetActive(true);
    }
}
