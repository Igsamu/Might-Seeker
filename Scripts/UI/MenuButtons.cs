using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ButtonNewGame()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
