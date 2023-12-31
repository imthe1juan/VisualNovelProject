using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class SuspectAccusation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    WinLoseTransition winLoseTransition;
    [SerializeField] Image image;
    [SerializeField] TMP_Text description;
    [SerializeField] GameObject confirmation;
    [SerializeField] Button yesButton;
    public Orientation orientation;
    public enum Orientation
    {
        Gardener, Artist, Pianist, Housekeeper
    }

    [SerializeField] Image main;
    [SerializeField] Sprite[] expressions;
    bool isMakingSure = false;
    private void Awake()
    {
        winLoseTransition = FindObjectOfType<WinLoseTransition>();
    }
    public void OnPointerEnter(PointerEventData eventData) 
    {
        image.color = new Color(1,1,1,1);

        main.sprite = expressions[0];

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, .5f);


        main.sprite = expressions[1];
    }
    public void OnPointerClick(PointerEventData eventData) 
    {
        AreYouSure();
    }
    private void Update()
    {
        if (!isMakingSure) return;
        image.color = new Color(1, 1, 1, 1);

        main.sprite = expressions[0];
    }
    public void AccusePerson()
    {
        switch (orientation)
        {
            case Orientation.Gardener:
                winLoseTransition.SetText($"Lack of evidence to accuse {Orientation.Gardener}", "You Lose", Color.red);

                break;
            case Orientation.Artist:
                winLoseTransition.SetText($"Evidence is sufficient to accuse {Orientation.Artist}", "You Win", Color.green);
                break;
            case Orientation.Pianist:
                winLoseTransition.SetText($"Lack of evidence to accuse {Orientation.Pianist}", "You Lose", Color.red);

                break;
            case Orientation.Housekeeper:
                winLoseTransition.SetText($"Lack of evidence to accuse {Orientation.Housekeeper}", "You Lose" ,Color.red);

                break;
            default:

                break;
        }
    }
    public void AreYouSure()
    {
        yesButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(AccusePerson);

        confirmation.SetActive(true);
        isMakingSure = true;
        switch (orientation)
        {
            case Orientation.Gardener:
                description.text = $"{ "Are you sure to accuse the " + Orientation.Gardener}";


                break;
            case Orientation.Artist:
                description.text = $"{ "Are you sure to accuse the " + Orientation.Artist}";


                break;
            case Orientation.Pianist:
                description.text = $"{ "Are you sure to accuse the " + Orientation.Pianist}";


                break;
            case Orientation.Housekeeper:
                description.text = $"{ "Are you sure to accuse the " + Orientation.Housekeeper}";

                break;
            default:

                break;
        }

    }
    public void Confirm() 
    {
        AccusePerson();
    }
    public void Close()
    {
        confirmation.SetActive(false);
        isMakingSure = false;
        image.color = new Color(1, 1, 1, .5f);


        main.sprite = expressions[1];
    }
    public Orientation GetOrientation()
    {
        return orientation;
    }
}
