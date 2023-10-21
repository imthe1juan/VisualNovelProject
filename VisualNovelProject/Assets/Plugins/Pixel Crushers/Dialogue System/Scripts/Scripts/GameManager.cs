using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    GameUI gameUI;
    public int phase;
    public int interoggationCount;
    int interoggationCurrentCount;
    public List<string> phaseName = new List<string>{"Night","Midnight","Dawn", "Morning"};
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        gameUI = GetComponent<GameUI>();
    }
    void Start()
    {
        interoggationCurrentCount = interoggationCount;
        gameUI.UpdateText(interoggationCurrentCount, phaseName[phase]);
    }
    public void Interrogate()
    {
        interoggationCurrentCount--;
        Debug.Log("Initiate Conversation");
        gameUI.UpdateText(interoggationCurrentCount, phaseName[phase]);
    }
    //Check After Conversation
    public void CheckPhase()
    {
        Debug.Log("Check");
        BlackOverlay.Instance.SetFade(false);
        if (interoggationCurrentCount <= 0)
        {
            InitializePhase();
        }
    }
    void InitializePhase()
    {
        phase++;
        interoggationCurrentCount = interoggationCount;
        gameUI.UpdateText(interoggationCurrentCount, phaseName[phase]);
    }

}
