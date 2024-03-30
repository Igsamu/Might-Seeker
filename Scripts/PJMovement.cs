using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJMovement : MonoBehaviour
{
    public float vel = 5f;

    public Animator animWalk;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 positionClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D colliderClic = Physics2D.OverlapPoint(positionClic);

            if (colliderClic != null && colliderClic.CompareTag("MoveZone"))
            {
                StartCoroutine(MoveToPosition(positionClic));
            }
        }
    }

    private IEnumerator MoveToPosition(Vector2 destino)
    {
        // Determinar la dirección del movimiento
        bool moveLeft = transform.position.x > destino.x;

        // Activar la animación correspondiente
        if (moveLeft)
            animWalk.SetBool("Left", true);
        else
            animWalk.SetBool("Right", true);

        while (Vector2.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino, vel * Time.deltaTime);

            yield return null;
        }

        // Desactivar la animación correspondiente cuando se detiene
        if (moveLeft)
            animWalk.SetBool("Left", false);
        else
            animWalk.SetBool("Right", false);
    }
}
