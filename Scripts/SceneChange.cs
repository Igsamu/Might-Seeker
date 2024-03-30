using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public PJMovement pjMovement;
    public Camera cam;

    public GameObject player;

    private void Start()
    {
        pjMovement = FindAnyObjectByType<PJMovement>();
        cam = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        //Cambio Muelle -> Bar
        if(gameObject.transform.position.x <= -2.9f && gameObject.transform.position.x >= -3.6f && gameObject.transform.position.y <= 0f)
        {
            gameObject.transform.position = new Vector3(-6.2f, -0.9f, 0f);
            transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            cam.gameObject.transform.position = new Vector3(-8f, 0f, -10f);
            pjMovement.StopAllCoroutines();
        }

        //Cambio Bar -> Muelle
        if (gameObject.transform.position.x >= -6.1f && gameObject.transform.position.x <= -5.2f && gameObject.transform.position.y <= 0f)
        {
            gameObject.transform.position = new Vector3(-2.8f, -1.5f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            cam.gameObject.transform.position = new Vector3(0f, 0f, -10f);
            pjMovement.StopAllCoroutines();
        }

        //Cambio Muelle -> Tienda
        if (gameObject.transform.position.x >= 2.8f && gameObject.transform.position.x <= 3.6f && gameObject.transform.position.y <= 0f)
        {
            gameObject.transform.position = new Vector3(5.3f, -1.5f, 0f);
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            cam.gameObject.transform.position = new Vector3(8f, 0f, -10f);
            pjMovement.StopAllCoroutines();
        }

        //Cambio Tienda -> Muelle
        if (gameObject.transform.position.x <= 5.2f && gameObject.transform.position.x >= 4.5f && gameObject.transform.position.y <= 0f)
        {
            gameObject.transform.position = new Vector3(2.7f, -1.5f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            cam.gameObject.transform.position = new Vector3(0f, 0f, -10f);
            pjMovement.StopAllCoroutines();
        }
    }
}
