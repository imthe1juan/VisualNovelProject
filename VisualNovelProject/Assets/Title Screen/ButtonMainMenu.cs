using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    MusicPlayer musicPlayer;
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
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickSFX.Play();
        musicPlayer.FadeOut(1);
        anim.SetBool("Fade", true);
        Blocked.SetActive(true);
        StartCoroutine(LoadNextScene());
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
    /*
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneNum);
    }*/
    IEnumerator LoadNextScene() 
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneNum);
    }
}
