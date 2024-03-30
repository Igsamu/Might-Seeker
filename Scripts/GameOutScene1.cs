using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOutScene1 : MonoBehaviour
{
    public GameObject sureOut;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(NoExit());
        }
    }
    private IEnumerator NoExit()
    {
        sureOut.SetActive(true);
        yield return new WaitForSeconds(4);
        sureOut.SetActive(false);
    }
}
