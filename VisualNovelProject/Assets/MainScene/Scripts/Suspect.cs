using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Suspect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Image roomImage;
    [SerializeField] Sprite hoverImage;
    [SerializeField] Sprite normalImage;


    [SerializeField] BlackOverlay interrogationTransition;
    public Orientation orientation;
    public enum Orientation
    {
        Gardener, Artist, Pianist, Housekeeper
    }

    [SerializeField] int suspectID;
    [SerializeField] int conversationid;
    public void OnPointerEnter(PointerEventData eventData)
    {
        roomImage.sprite = hoverImage;
        gameObject.transform.localScale += new Vector3(.1f, .1f, .1f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        roomImage.sprite = normalImage;
        gameObject.transform.localScale -= new Vector3(.1f, .1f, .1f);

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Interrogate();
    }
    void Interrogate()
    {
        StartCoroutine(InterrogateCoroutine());
    }
    IEnumerator InterrogateCoroutine()
    {
        interrogationTransition.SetFade(true);
        yield return new WaitForSeconds(1);
        GameManager.Instance.Interrogate();

        switch (orientation) 
        {
            case Orientation.Gardener:
                DialogueManager.StartConversation($"{Orientation.Gardener}{conversationid}");
                break;
            case Orientation.Artist:
                DialogueManager.StartConversation($"{Orientation.Artist}{conversationid}");

                break;
            case Orientation.Pianist:
                DialogueManager.StartConversation($"{Orientation.Pianist}{conversationid}");

                break;
            case Orientation.Housekeeper:
                DialogueManager.StartConversation($"{Orientation.Housekeeper}{conversationid}");

                break;
            default:

                break;
        }
        interrogationTransition.SetFade(false, 1f);
    }
}
