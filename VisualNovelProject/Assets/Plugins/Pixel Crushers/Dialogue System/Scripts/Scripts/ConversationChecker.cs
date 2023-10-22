using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationChecker : MonoBehaviour
{
    public static ConversationChecker Instance;

    public int requiredEvidence;
    public int numOfEvidence;
    public bool artistGuilty = false;
    public enum Orientation
    {
        Gardener, Artist, Pianist, Housekeeper
    }
    private void Awake()
    {
  
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void CheckGardenerConversation()
    {
        int currentPhase = GameManager.Instance.phase;
        switch (currentPhase) 
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    public void CheckArtistConversation()
    {
        int currentPhase = GameManager.Instance.phase;
        switch (currentPhase)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                AddEvidence();
                break;
        }
    }
    public void CheckPianistConversation()
    {
        int currentPhase = GameManager.Instance.phase;
        switch (currentPhase)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    public void CheckHousekeeperConversation()
    {
        int currentPhase = GameManager.Instance.phase;
        switch (currentPhase)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    public void AddEvidence() 
    {
        numOfEvidence++;
        if(numOfEvidence >= requiredEvidence) 
        {
            artistGuilty = true;
        }
    }

}
