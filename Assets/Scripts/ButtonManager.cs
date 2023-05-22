using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits"); 
    }
}