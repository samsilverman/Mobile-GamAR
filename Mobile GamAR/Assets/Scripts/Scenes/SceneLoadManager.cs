using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadPlayingCardsScene()
    {
        SceneManager.LoadScene("PlayingCardsScene");
    }

    public void LoadJacksScene()
    {
        SceneManager.LoadScene("JacksScene");
    }
}
