using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject OptionMenu;
   public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        OptionMenu.SetActive(true);
    }

    public void OptionsExit()
    {
        OptionMenu.SetActive(false);
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void WindowedScreen()
    {
        Screen.fullScreen = false;
    }
}
