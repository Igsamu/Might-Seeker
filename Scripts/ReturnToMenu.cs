using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
