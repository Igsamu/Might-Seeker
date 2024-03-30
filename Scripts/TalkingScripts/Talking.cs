using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talking : MonoBehaviour
{
    public PJMovement pjMovement;
    public Sonar sonar;

    public Camera cam;
    public GameObject player;
    public Animator fadeOutAnim;
    public GameObject fadeOutObject;
    public GameObject instWalk;

    [Header("Bocadillos")]
    public GameObject playerBallon;
    public GameObject playerBallon2;
    public GameObject oldManBallon;
    public GameObject fishermanBallon;
    public GameObject turist1Ballon;
    public GameObject turist2Ballon;
    public GameObject shelterBallon;
    public GameObject fishermanBoatBallon;

    [Header("Textos")]
    public TMP_Text playerText;
    public TMP_Text playerText2;
    public TMP_Text oldManText;
    public TMP_Text fishermanText;
    public TMP_Text turist1Text;
    public TMP_Text turist2Text;
    public TMP_Text shelterText;
    public TMP_Text fishermanBoatText;

    [Header("Animator")]
    public Animator playerAnim;
    public Animator oldManAnim;
    public Animator fishermanAnim;
    public Animator shelterAnim;
    public Animator fishermanBoatAnim;
    public Animator fadeIn;

    [Header("Objetos escena")]
    public GameObject flamenco;
    public GameObject cinta;

    [Header("Arrays")]
    public string[] playerTalk;
    public string[] oldManTalk;
    public string[] fishermanTalk;
    public string[] turist1Talk;
    public string[] turist2Talk;
    public string[] shelterTalk;
    public string[] fishermanBoatTalk;

    [Header("Colliders")]
    public GameObject cintaColl;
    public GameObject flamenColl;

    [Header("Sonidos")]
    public AudioSource talk1;
    public AudioSource talk2;
    public AudioSource talk3;
    public AudioSource water;

    //Dialogs Ints
    private int oldManDialog = 0;
    private int fishermanDialog;
    private int turist1Dialog;
    private int turist2Dialog;
    private int shelterDialog;
    private int fishermanBoatDialog;

    //In bools
    private bool oldManIn;
    private bool fishermanIn;
    private bool turist1In;
    private bool turist2In;
    private bool shelterIn;
    private bool flamenIn;
    private bool cinIn;
    private bool nessyIn;
    private bool fisherman2In;

    //Others
    public Button talkButton;
    public Button intButton;
    private bool secondTalk;
    private bool oldManCanTalk;
    private bool isMapTalk;
    private bool haveFlamen;
    private bool haveCint;
    private bool canShip;
    public bool canSonar;
    private bool fishermanHasTalk;

    private void Start()
    {
        pjMovement = FindAnyObjectByType<PJMovement>();
        sonar = FindAnyObjectByType<Sonar>();
        StartCoroutine(FadeIn());
    }
    private void Update()
    {
        if (sonar.isNessy == true)
        {
            sonar.isNessy = false;
            StartCoroutine(FishermanBoatText2());
        }
    }

    public void TalkButton()
    {
        if(oldManIn)
        {
            if (isMapTalk)
            {
                if(oldManCanTalk)
                {
                    if(!canShip)
                    {
                        StartCoroutine(OldManText());
                    }
                    else if(canShip)
                    {
                        StartCoroutine(OldManNoTalk());
                    }
                    
                }
                else
                {
                    StartCoroutine(OldManNoTalk());
                }
            }
            else
            {
                StartCoroutine(OldManNoTalk());
            }
        }

        if(fishermanIn)
        {
            if(!haveCint)
            {
                if(!fishermanHasTalk)
                {
                    StartCoroutine(FishermanText1());
                }
                else if(fishermanHasTalk)
                {
                    StartCoroutine(FishermanNoTalk());
                }
            }
            else if(haveCint)
            {
                if(fishermanHasTalk)
                {
                    if (canShip)
                    {
                        StartCoroutine(FishermanText2());
                    }
                    else if (!canShip)
                    {
                        StartCoroutine(FishermanNoTalk());
                    }
                }
                else if(!fishermanHasTalk)
                {
                    StartCoroutine(FishermanText1());
                }
            }
            else
            {
                StartCoroutine(FishermanNoTalk());
            }
        }

        if (turist1In == true)
        {
            StartCoroutine(Turist1Text());
        }

        if (turist2In == true)
        {
            StartCoroutine(Turist2Text());
        }

        if(shelterIn)
        {
            if(!secondTalk)
            {
                StartCoroutine(ShelterText1());
            }
            else if(secondTalk)
            {
                if(haveFlamen)
                {
                    if(!isMapTalk)
                    {
                        StartCoroutine(ShelterText2());
                    }
                    else if (isMapTalk)
                    {
                        StartCoroutine(ShelterNoTalk());
                    }
                }
                else
                {
                    StartCoroutine(ShelterNoTalk());
                }
            }
            else
            {
                StartCoroutine(ShelterNoTalk());
            }
        }

        if (fisherman2In == true)
        {
            StartCoroutine(FishermanBoatText());
        }
    }

    public void InterButton()
    {
        if (flamenIn == true)
        {
            StartCoroutine(FlamenText());
        }
        if (cinIn == true)
        {
            StartCoroutine(CintaText());
        }
        if (nessyIn == true)
        {
            StartCoroutine(NessyText());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TalkTimeOldMan"))
        {
            oldManIn = true;
        }
        if (other.CompareTag("TalkTimeFisherman"))
        {
            fishermanIn = true;
        }
        if (other.CompareTag("TalkTimeTurist1"))
        {
            turist1In = true;
        }
        if (other.CompareTag("TalkTimeTurist2"))
        {
            turist2In = true;
        }
        if (other.CompareTag("TalkTimeShelter"))
        {
            shelterIn = true;
        }
        if (other.CompareTag("FlamenColl"))
        {
            flamenIn = true;
        }
        if (other.CompareTag("CintaColl"))
        {
            cinIn = true;
        }
        if (other.CompareTag("NessyColl"))
        {
            nessyIn = true;
        }
        if (other.CompareTag("TalkTimeFisherman2"))
        {
            fisherman2In = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TalkTimeOldMan"))
        {
            oldManIn = false;
        }
        if (other.CompareTag("TalkTimeFisherman"))
        {
            fishermanIn = false;
        }
        if (other.CompareTag("TalkTimeTurist1"))
        {
            turist1In = false;
        }
        if (other.CompareTag("TalkTimeTurist2"))
        {
            turist2In = false;
        }
        if (other.CompareTag("TalkTimeShelter"))
        {
            shelterIn = false;
        }
        if (other.CompareTag("FlamenColl"))
        {
            flamenIn = false;
        }
        if (other.CompareTag("CintaColl"))
        {
            cinIn = false;
        }
        if (other.CompareTag("NessyColl"))
        {
            nessyIn = false;
        }
        if (other.CompareTag("TalkTimeFisherman2"))
        {
            fisherman2In = false;
        }
    }

    public IEnumerator OldManText()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 0));

        yield return new WaitUntil(() => oldManDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(0));

        yield return new WaitUntil(() => oldManDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 1));

        yield return new WaitUntil(() => oldManDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(1));

        yield return new WaitUntil(() => oldManDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 2));

        yield return new WaitUntil(() => oldManDialog == 5);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(2));

        yield return new WaitUntil(() => oldManDialog == 6);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 3));

        yield return new WaitUntil(() => oldManDialog == 7);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(3));

        yield return new WaitUntil(() => oldManDialog == 8);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 4));

        yield return new WaitUntil(() => oldManDialog == 9);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(4));

        yield return new WaitUntil(() => oldManDialog == 10);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 5));

        yield return new WaitUntil(() => oldManDialog == 11);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(5));

        yield return new WaitUntil(() => oldManDialog == 12);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 6));

        yield return new WaitUntil(() => oldManDialog == 13);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(6));

        yield return new WaitUntil(() => oldManDialog == 14);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 7));

        yield return new WaitUntil(() => oldManDialog == 15);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(7));

        yield return new WaitUntil(() => oldManDialog == 16);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(oldManBallon, oldManAnim, oldManText, oldManDialog, 8));

        yield return new WaitUntil(() => oldManDialog == 17);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(OldManTalk(8));

        yield return new WaitUntil(() => oldManDialog == 18);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        oldManBallon.SetActive(false);
        oldManAnim.SetBool("Talk", false);
        talk1.Stop();
        oldManText.text = "";
        canShip = true;
        oldManDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    //Player lineas 15 a 19
    public IEnumerator FishermanText1()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(fishermanBallon, fishermanAnim, fishermanText, fishermanDialog, 15));

        yield return new WaitUntil(() => fishermanDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanTalk(0));

        yield return new WaitUntil(() => fishermanDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(fishermanBallon, fishermanAnim, fishermanText, fishermanDialog, 16));

        yield return new WaitUntil(() => fishermanDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanTalk(1));


        yield return new WaitUntil(() => fishermanDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(fishermanBallon, fishermanAnim, fishermanText, fishermanDialog, 17));

        yield return new WaitUntil(() => fishermanDialog == 5);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanTalk(2));

        yield return new WaitUntil(() => fishermanDialog == 6);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        fishermanBallon.SetActive(false);
        fishermanAnim.SetBool("Talk", false);
        fishermanHasTalk = true;
        talk3.Stop();
        fishermanText.text = "";
        fishermanDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator FishermanText2()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(fishermanBallon, fishermanAnim, fishermanText, fishermanDialog, 18));

        yield return new WaitUntil(() => fishermanDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanTalk(3));

        yield return new WaitUntil(() => fishermanDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(fishermanBallon, fishermanAnim, fishermanText, fishermanDialog, 19));

        yield return new WaitUntil(() => fishermanDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanTalk(4));

        yield return new WaitUntil(() => fishermanDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        fishermanBallon.SetActive(false);
        fishermanAnim.SetBool("Talk", false);
        talk3.Stop();
        fishermanText.text = "";
        fishermanDialog = 0;

        player.gameObject.transform.position = new Vector3(-0.5f, 3.5f, 0f);
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        cam.gameObject.transform.position = new Vector3(0f, 5f, -10f);
        pjMovement.StopAllCoroutines();

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator FishermanBoatText()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(fishermanBoatBallon, fishermanBoatAnim, fishermanBoatText, fishermanBoatDialog, 26));

        yield return new WaitUntil(() => fishermanBoatDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanBoatTalk(0));

        yield return new WaitUntil(() => fishermanBoatDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(fishermanBoatBallon, fishermanBoatAnim, fishermanBoatText, fishermanBoatDialog, 27));

        yield return new WaitUntil(() => fishermanBoatDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanBoatTalk(1));

        yield return new WaitUntil(() => fishermanBoatDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        fishermanBoatBallon.SetActive(false);
        fishermanBoatAnim.SetBool("Talk", false);
        fishermanBoatText.text = "";
        talk3.Stop();
        fishermanBoatDialog = 0;
        canSonar = true;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator FishermanBoatText2()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;
        fadeOutObject.SetActive(true);

        StartCoroutine(PlayerTalk(fishermanBoatBallon, fishermanBoatAnim, fishermanBoatText, fishermanBoatDialog, 28));

        yield return new WaitUntil(() => fishermanBoatDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(FishermanBoatTalk(2));

        yield return new WaitUntil(() => fishermanBoatDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(fishermanBoatBallon, fishermanBoatAnim, fishermanBoatText, fishermanBoatDialog, 29));

        yield return new WaitUntil(() => fishermanBoatDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk3.Stop();
        playerText.text = "";
        fishermanBoatDialog = 0;
        fadeOutAnim.SetBool("Fade", true);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MapScene");
    }

    public IEnumerator Turist1Text()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(Turist1Talk(0));

        yield return new WaitUntil(() => turist1Dialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        turist1Ballon.SetActive(false);
        talk1.Stop();
        turist1Text.text = "";
        turist1Dialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }
    public IEnumerator Turist2Text()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(Turist2Talk(0));

        yield return new WaitUntil(() => turist2Dialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        turist2Ballon.SetActive(false);
        turist2Text.text = "";
        talk2.Stop();
        turist2Dialog = 0;
        oldManCanTalk = true;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    //Player lineas 9 a 12 primera parte
    public IEnumerator ShelterText1()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 9));

        yield return new WaitUntil(() => shelterDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(0));

        yield return new WaitUntil(() => shelterDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 10));

        yield return new WaitUntil(() => shelterDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(1));

        yield return new WaitUntil(() => shelterDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 11));

        yield return new WaitUntil(() => shelterDialog == 5);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(2));

        yield return new WaitUntil(() => shelterDialog == 6);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 12));

        yield return new WaitUntil(() => shelterDialog == 7);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(3));

        yield return new WaitUntil(() => shelterDialog == 8);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        shelterBallon.SetActive(false);
        shelterAnim.SetBool("Talk", false);
        shelterText.text = "";
        talk2.Stop();
        shelterDialog = 0;
        secondTalk = true;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator ShelterText2()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 13));

        yield return new WaitUntil(() => shelterDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(4));

        yield return new WaitUntil(() => shelterDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 14));

        yield return new WaitUntil(() => shelterDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(5));

        yield return new WaitUntil(() => shelterDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        shelterBallon.SetActive(false);
        shelterAnim.SetBool("Talk", false);
        talk2.Stop();
        shelterText.text = "";
        shelterDialog = 0;
        isMapTalk = true;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator FlamenText()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        playerBallon2.SetActive(true);
        playerAnim.SetBool("Talk", true);
        playerText2.text = playerTalk[20];

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        water.Play();
        Destroy(flamenco);
        Destroy(flamenColl);
        haveFlamen = true;
        playerBallon2.SetActive(false);
        talk1.Stop();
        playerAnim.SetBool("Talk", false);
        playerText2.text = "";

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator CintaText()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 21));

        yield return new WaitUntil(() => shelterDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(6));

        yield return new WaitUntil(() => shelterDialog == 2);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 22));

        yield return new WaitUntil(() => shelterDialog == 3);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(7));

        yield return new WaitUntil(() => shelterDialog == 4);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 23));

        yield return new WaitUntil(() => shelterDialog == 5);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(ShelterTalk(8));

        yield return new WaitUntil(() => shelterDialog == 6);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 24));


        yield return new WaitUntil(() => shelterDialog == 7);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        Destroy(cinta);
        Destroy(cintaColl);
        haveCint = true;
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk1.Stop();
        playerText.text = "";
        shelterDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator NessyText()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(PlayerTalk(shelterBallon, shelterAnim, shelterText, shelterDialog, 25));

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk1.Stop();
        playerText.text = "";
        shelterDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator OldManNoTalk()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(OldManTalk(9));

        yield return new WaitUntil(() => oldManDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        oldManBallon.SetActive(false);
        oldManAnim.SetBool("Talk", false);
        oldManText.text = "";
        talk1.Stop();
        oldManDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }
    public IEnumerator FishermanNoTalk()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(FishermanTalk(5));

        yield return new WaitUntil(() => fishermanDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        fishermanBallon.SetActive(false);
        fishermanAnim.SetBool("Talk", false);
        fishermanText.text = "";
        talk3.Stop();
        fishermanDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    public IEnumerator ShelterNoTalk()
    {
        pjMovement.enabled = false;
        talkButton.interactable = false;
        intButton.interactable = false;

        StartCoroutine(ShelterTalk(9));

        yield return new WaitUntil(() => shelterDialog == 1);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        shelterBallon.SetActive(false);
        shelterAnim.SetBool("Talk", false);
        talk3.Stop();
        shelterText.text = "";
        shelterDialog = 0;

        pjMovement.enabled = true;
        talkButton.interactable = true;
        intButton.interactable = true;
    }

    private IEnumerator PlayerTalk(GameObject ballon, Animator anim, TMP_Text text, int dialog, int textNum)
    {
        ballon.SetActive(false);
        anim.SetBool("Talk", false);
        text.text = "";
        talk1.Stop();
        talk2.Stop();
        talk3.Stop();
        dialog++;
        playerBallon.SetActive(true);
        playerAnim.SetBool("Talk", true);
        talk1.Play();
        playerText.text = playerTalk[textNum];
        if (oldManIn)
        {
            OldManReturn(ballon, anim, text, dialog);
        }
        else if (fishermanIn)
        {
            FishermanReturn(ballon, anim, text, dialog);
        }
        else if (shelterIn)
        {
            ShelterReturn(ballon, anim, text, dialog);
        }
        else if (fisherman2In)
        {
            FishermanBoatReturn(ballon, anim, text, dialog);
        }

        yield return null;
    }

    private void OldManReturn(GameObject ballon, Animator anim, TMP_Text text, int dialog)
    {
        oldManBallon = ballon;
        oldManAnim = anim;
        oldManText = text;
        oldManDialog = dialog;
    }
    private void FishermanReturn(GameObject ballon, Animator anim, TMP_Text text, int dialog)
    {
        fishermanBallon = ballon;
        fishermanAnim = anim;
        fishermanText = text;
        fishermanDialog = dialog;
    }

    private void FishermanBoatReturn(GameObject ballon, Animator anim, TMP_Text text, int dialog)
    {
        fishermanBoatBallon = ballon;
        fishermanBoatAnim = anim;
        fishermanBoatText = text;
        fishermanBoatDialog = dialog;
    }
    private void ShelterReturn(GameObject ballon, Animator anim, TMP_Text text, int dialog)
    {
        shelterBallon = ballon;
        shelterAnim = anim;
        shelterText = text;
        shelterDialog = dialog;
    }

    private IEnumerator OldManTalk(int textNum)
    {
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        playerText.text = "";
        talk1.Stop();
        oldManDialog++;
        oldManBallon.SetActive(true);
        talk1.Play();
        oldManAnim.SetBool("Talk", true);
        oldManText.text = oldManTalk[textNum];
        yield return null;
    }

    private IEnumerator FishermanTalk(int textNum)
    {
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk1.Stop();
        playerText.text = "";
        fishermanDialog++;
        fishermanBallon.SetActive(true);
        talk3.Play();
        fishermanAnim.SetBool("Talk", true);
        fishermanText.text = fishermanTalk[textNum];
        yield return null;
    }

    private IEnumerator FishermanBoatTalk(int textNum)
    {
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk1.Stop();
        playerText.text = "";
        fishermanBoatDialog++;
        fishermanBoatBallon.SetActive(true);
        talk3.Play();
        fishermanBoatAnim.SetBool("Talk", true);
        fishermanBoatText.text = fishermanBoatTalk[textNum];
        yield return null;
    }
    private IEnumerator Turist1Talk(int textNum)
    {
        turist1Ballon.SetActive(true);
        talk1.Play();
        turist1Dialog++;
        turist1Text.text = turist1Talk[textNum];
        yield return null;
    }
    private IEnumerator Turist2Talk(int textNum)
    {
        turist2Ballon.SetActive(true);
        talk2.Play();
        turist2Dialog++;
        turist2Text.text = turist2Talk[textNum];
        yield return null;
    }
    private IEnumerator ShelterTalk(int textNum)
    {
        playerBallon.SetActive(false);
        playerAnim.SetBool("Talk", false);
        talk1.Stop();
        playerText.text = "";
        shelterDialog++;
        shelterBallon.SetActive(true);
        talk2.Play();
        shelterAnim.SetBool("Talk", true);
        shelterText.text = shelterTalk[textNum];
        yield return null;
    }

    private IEnumerator FadeIn()
    {
        pjMovement.enabled = false;
        fadeIn.SetBool("FadeIn", true);
        yield return new WaitForSeconds(2f);
        fadeIn.SetBool("FadeIn", false);
        fadeOutObject.SetActive(false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        instWalk.SetActive(false);
        pjMovement.enabled = true;
    }
}
