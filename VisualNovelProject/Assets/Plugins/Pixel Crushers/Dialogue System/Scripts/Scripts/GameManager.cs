using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] BlackOverlay blackOverlay;
    [SerializeField] GameObject[] gameParts;

    public int phase;
    public int interoggationCount;
    int interoggationCurrentCount;

    public List<string> phaseName = new List<string>{"Night","Midnight","Dawn", "Morning", "Accusation"};
    PhaseTransitionUI phaseTransitionUI;
    GameUI gameUI;
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

        phaseTransitionUI = FindObjectOfType<PhaseTransitionUI>();
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
        blackOverlay.SetFade(false, 1);

        if (interoggationCurrentCount <= 0) //phaseName.Count - 1
        {
            InitializePhase();
            phaseTransitionUI.InitiateTransition();
        }
    }
    public void InitializePhase()
    {
        phase++;
        if(phase >= 4)//phaseName.Count -1
        {
            gameParts[0].SetActive(false);
            gameParts[1].SetActive(true);

            blackOverlay.SetFade(true, 1);

            gameUI.UpdateText("ACCUSE SOMEONE!", phaseName[phase]);
        }
        else
        {
            interoggationCurrentCount = interoggationCount;
            gameUI.UpdateText(interoggationCurrentCount, phaseName[phase]);
        }

    }
    public string GetCurrentPhase()
    {
        return phaseName[phase];
    }
}
