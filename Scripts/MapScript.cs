using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    public GameObject image;
    public void OnClickButton()
    {
        StartCoroutine(CreateImage());
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public IEnumerator CreateImage()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(2);
        image.SetActive(false);
    }
}
