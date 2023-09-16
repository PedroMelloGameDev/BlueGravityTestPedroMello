using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;
    bool isHowToPlayOpen;

    public void Play()
    {
        SceneManager.LoadScene("LittleShopWorld", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void HowToPlay()
    {
        if(!isHowToPlayOpen)
        {
            howToPlay.SetActive(true);
            isHowToPlayOpen = true;
        }
        else if(isHowToPlayOpen)
        {
            howToPlay.SetActive(false);
            isHowToPlayOpen = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
