using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject HoverPanel;
    public AudioSource SoundFX;
    public AudioSource onClickSFX;
    public  GameObject Fade;
    public GameObject Blocked;

    Animator anim;
    
    public int sceneNum;


    void Start()
    {
        anim = Fade.GetComponent<Animator>();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickSFX.Play();
        anim.Play("FadeAnim");
        StartCoroutine(FadeOut());
        Blocked.SetActive(true);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel.SetActive(true);
        SoundFX.Play();
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        HoverPanel.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneNum);
    }

}
