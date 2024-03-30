using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TalkignAtTheBar : MonoBehaviour
{
    [Header("Recuadros textos")]
    public TMP_Text playerText;
    public TMP_Text compText;

    [Header("Bocadillos")]
    public GameObject playerBalloon;
    public GameObject compBalloon;

    [Header("Texto")]
    public string[] playerTalk;
    public string[] compTalk;

    [Header("Animaciones")]
    public Animator playerAnim;
    public Animator compAnim;
    public Animator panelFadeOut;

    //Otros
    public GameObject startTalk;
    public AudioSource talkAudio;
    public AudioSource talkAudio2;
    private int dialog;

    private void Start()
    {
        StartCoroutine(FirstText());
    }

    private IEnumerator FirstText()
    {
        yield return new WaitForSeconds(2f);
        startTalk.SetActive(true);

        yield return new WaitUntil(() => Input.GetMouseButton(0));
        startTalk.SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(GameTalking());
    }

    public IEnumerator GameTalking()
    {
        StartCoroutine(PlayerTalk(0));

        yield return new WaitUntil(() => dialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(0));

        yield return new WaitUntil(() => dialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(1));

        yield return new WaitUntil(() => dialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(1));

        yield return new WaitUntil(() => dialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(2));

        yield return new WaitUntil(() => dialog == 5);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(2));

        yield return new WaitUntil(() => dialog == 6);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(3));

        yield return new WaitUntil(() => dialog == 7);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(3));

        yield return new WaitUntil(() => dialog == 8);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(4));

        yield return new WaitUntil(() => dialog == 9);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(4));

        yield return new WaitUntil(() => dialog == 10);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(5));

        yield return new WaitUntil(() => dialog == 11);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(CompTalk(5));

        yield return new WaitUntil(() => dialog == 12);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(6));

        yield return new WaitUntil(() => dialog == 13);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        playerBalloon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        playerText.text = "";
        talkAudio.Stop();

        yield return new WaitForSeconds(1);
        panelFadeOut.SetBool("Fade", true);

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("NessLake");
    }

    private IEnumerator PlayerTalk(int textNum)
    {
        compBalloon.SetActive(false);
        compAnim.SetBool("Talk", false);
        compText.text = "";
        talkAudio2.Stop();
        dialog++;
        playerBalloon.SetActive(true);
        playerAnim.SetBool("Talk", true);
        playerText.text = playerTalk[textNum];
        talkAudio.Play();
        yield return null;
    }

    private IEnumerator CompTalk(int textNum)
    {
        playerBalloon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        playerText.text = "";
        talkAudio.Stop();
        dialog++;
        compBalloon.SetActive(true);
        compAnim.SetBool("Talk", true);
        compText.text = compTalk[textNum];
        talkAudio2.Play();
        yield return null;
    }
}
