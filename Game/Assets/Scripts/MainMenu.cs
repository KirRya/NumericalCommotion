using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameEasy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HealthSystem.numOfHearths = 5;
        HealthSystem.health = 5;
    }
    public void PlayGameMeduim()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HealthSystem.numOfHearths = 3;
        HealthSystem.health = 3;
    }
    public void PlayGameHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        HealthSystem.numOfHearths = 1;
        HealthSystem.health = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
