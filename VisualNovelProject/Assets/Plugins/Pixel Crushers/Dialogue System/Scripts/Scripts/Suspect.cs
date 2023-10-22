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


    ConversationChecker conversationChecker;
    [SerializeField] BlackOverlay blackOverlay;
    public Orientation orientation;
    public enum Orientation{
        Gardener, Artist, Pianist, Housekeeper
    }

    [SerializeField] int suspectID;
    [SerializeField] int conversationid;
    Button button;
    void Awake()
    {
        conversationChecker = FindObjectOfType<ConversationChecker>();
        //button = GetComponent<Button>();
        //button.onClick.AddListener(Interrogate);
    }
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
        //Are you sure
    }
    void Interrogate()
    {
        blackOverlay.SetFade(true, 1f);
        StartCoroutine(InterrogateCoroutine());
    }
    IEnumerator InterrogateCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.Interrogate();
        Debug.Log("Start");
        switch (orientation) 
        {
            case Orientation.Gardener:
                conversationChecker.CheckGardenerConversation();
                DialogueManager.StartConversation($"{Orientation.Gardener}{conversationid}", transform, transform);
                break;
            case Orientation.Artist:
                conversationChecker.CheckArtistConversation();
                DialogueManager.StartConversation($"{Orientation.Artist}{conversationid}", transform, transform);

                break;
            case Orientation.Pianist:
                conversationChecker.CheckPianistConversation();
                DialogueManager.StartConversation($"{Orientation.Pianist}{conversationid}", transform, transform);

                break;
            case Orientation.Housekeeper:
                conversationChecker.CheckHousekeeperConversation();
                DialogueManager.StartConversation($"{Orientation.Housekeeper}{conversationid}", transform, transform);

                break;
            default:

                break;
        }
    }
}
