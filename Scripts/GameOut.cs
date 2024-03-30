using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOut : MonoBehaviour
{
    public GameObject sureOut;
    public GameObject talkButton;
    public GameObject interButton;
    public PJMovement pJMovement;

    private void Start()
    {
        pJMovement = FindAnyObjectByType<PJMovement>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            sureOut.SetActive(true);
            pJMovement.enabled = false;
            talkButton.SetActive(false);
            interButton.SetActive(false);
        }
    }

    public void yesBut()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void noBut()
    {
        sureOut.SetActive(false);
        pJMovement.enabled = true;
        talkButton.SetActive(true);
        interButton.SetActive(true);
    }
}
