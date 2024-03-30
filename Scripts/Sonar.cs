using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonar : MonoBehaviour
{
    public Talking talking;
    public Camera cam;

    public GameObject[] backgrounds;

    public Animator nessyAnim;
    public GameObject befBG;
    public bool isIn;
    public int currentBG;
    public AudioSource sonarSound;
    public AudioSource errorSound;
    public AudioSource succesSound;

    public GameObject talkBut;
    public GameObject intBut;
    public GameObject instr;

    public bool isNessy;
    public bool canPlay;

    private void Start()
    {
        talking = FindAnyObjectByType<Talking>();
    }

    private void Update()
    {
        if(talking.canSonar == true)
        {
            StartCoroutine(StartGame());
            talking.canSonar = false;
        }

        if(isIn == true && Input.GetKeyDown(KeyCode.Space) && currentBG != 5)
        {
            currentBG++;
            succesSound.Play();
            TPosition();
        }
        else if(isIn == true && Input.GetKeyDown(KeyCode.Space) && currentBG == 5)
        {
            currentBG++;
        }
        else if(isIn == false && canPlay == true && Input.GetKeyDown(KeyCode.Space))
        {
            currentBG--;
            errorSound.Play();
            if (currentBG <= 0)
            {
                currentBG = 0;
            }
            TPosition();
        }

        if(currentBG == 6)
        {
            cam.gameObject.transform.position = new Vector3(0, 5, -10);
            nessyAnim.SetBool("Move", true);
            isNessy = true;
            sonarSound.Stop();
            currentBG = 7;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Taken"))
        {
            isIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Taken"))
        {
            isIn = false;
        }
    }

    private void TPosition()
    {
        Destroy(befBG);
        befBG = Instantiate(backgrounds[currentBG], new Vector3 (0f,10f,0f), Quaternion.identity);
    }

    private IEnumerator StartGame()
    {
        cam.gameObject.transform.position = new Vector3(0, 10, -10);
        talkBut.SetActive(false);
        intBut.SetActive(false);
        instr.SetActive(true);
        sonarSound.Play();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        instr.SetActive(false);
        yield return new WaitForSeconds(2);
        canPlay = true;
        befBG = Instantiate(backgrounds[0], new Vector3(0f, 10f, 0f), Quaternion.identity);
    }
}