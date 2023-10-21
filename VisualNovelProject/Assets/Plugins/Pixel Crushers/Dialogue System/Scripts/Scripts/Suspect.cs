using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
public class Suspect : MonoBehaviour
{
    public Orientation orientation;
    public enum Orientation{
        Gardener, Artist, Pianist, Housekeeper
    }

    [SerializeField] int suspectID;
    [SerializeField] int conversationid;
    public List<string> suspectNameList = new List<string> { "Gardener", "Artist", "Pianist", "Housekeeper" };
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Interrogate);
    }

    void Interrogate()
    {
        BlackOverlay.Instance.SetFade(true);
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
                DialogueManager.StartConversation($"{Orientation.Gardener}{conversationid}", transform, transform);

                break;
            case Orientation.Artist:
                DialogueManager.StartConversation($"{Orientation.Artist}{conversationid}", transform, transform);

                break;
            case Orientation.Pianist:
                DialogueManager.StartConversation($"{Orientation.Pianist}{conversationid}", transform, transform);

                break;
            case Orientation.Housekeeper:
                DialogueManager.StartConversation($"{Orientation.Housekeeper}{conversationid}", transform, transform);

                break;
            default:

                break;
        }
    }
}
