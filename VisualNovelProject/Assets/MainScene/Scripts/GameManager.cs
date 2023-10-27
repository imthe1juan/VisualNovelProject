using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] BlackOverlay blackOverlay;
    [SerializeField] GameObject[] gameParts;
    public List<string> phaseNameList = new List<string>();
    public List<Sprite> phaseSpriteList = new List<Sprite>();

    public int phase;
    public int interoggationCount;
    int interoggationCurrentCount;

    PhaseTransitionUI phaseTransitionUI;
    GameUI gameUI;
    bool accusationPhase = false;
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
        phaseTransitionUI.InitiateTransition();
        interoggationCurrentCount = interoggationCount;
        gameUI.UpdateText(interoggationCurrentCount, phaseSpriteList[phase]);
    }
    private void Update()
    {
        if(accusationPhase == false) 
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SkipToAccusationPhase();
            }
        }
    }
    public void Interrogate()
    {
        interoggationCurrentCount--;
        Debug.Log("Initiate Conversation");
        gameUI.UpdateText(interoggationCurrentCount, phaseSpriteList[phase]);
    }
    //Check After Conversation
    public void CheckPhase()
    {
        blackOverlay.SetFade(false, 1f, .5f);
        if (interoggationCurrentCount <= 0) //phaseName.Count - 1
        {
            InitializePhase();
            phaseTransitionUI.InitiateTransition();
        }
    }
    public void SkipToAccusationPhase() 
    {
        accusationPhase = true;
        phase++;

        phaseTransitionUI.InitiateTransition();

        gameParts[0].SetActive(false);
        gameParts[1].SetActive(true);


        gameUI.UpdateImage("ACCUSE SOMEONE!", phaseSpriteList[phase]);
    }
    public void InitializePhase()
    {
        phase++;
        if(phase >= 1)//phaseName.Count -1
        {
            accusationPhase = true;
            gameParts[0].SetActive(false);
            gameParts[1].SetActive(true);

            blackOverlay.SetFade(true);

            gameUI.UpdateImage("ACCUSE SOMEONE!", phaseSpriteList[phase]);
        }
        else
        {
            interoggationCurrentCount = interoggationCount;
            gameUI.UpdateText(interoggationCurrentCount, phaseSpriteList[phase]);
        }

    }
    public string GetCurrentPhase()
    {
        return phaseNameList[phase];
    }
}
