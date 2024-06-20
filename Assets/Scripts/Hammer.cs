using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Tooltip("Velocidad de bajada")]
    public float downSpeed = 4f;
    [Tooltip("Velocidad de subida")]
    public float upSpeed = 1f;
    [Tooltip("A que angulo rota en grados")]
    public float maxRotationAngle = 90.0f;
    [Tooltip("Tiempo que espera estando arriba y abajo")]
    public float waitTime;
    [Tooltip("Tiempo que va a afectar a la velocidad")]
    public float slowedTime;

    private bool isGoingDown = true;
    private Quaternion endRotation;
    private float rotationProgress = 0.0f;

    void Start()
    {
        endRotation = Quaternion.Euler(0,0, maxRotationAngle);
        StartCoroutine(HammerMovement());
    }

    IEnumerator HammerMovement()
    {
        float initialWaitTime = Random.Range(1, 6);
        yield return new WaitForSeconds(initialWaitTime);
        while (true)
        {
            if (isGoingDown)
            {
                // Incrementa el progreso de la rotación basandose de la downspeed
                rotationProgress += Time.deltaTime * downSpeed;

                // lo rota lol
                transform.rotation = Quaternion.Lerp(Quaternion.identity, endRotation, rotationProgress);

                // verifica si llego abajo asi espera y hace que suba
                if (rotationProgress >= 1.0f)
                {
                    rotationProgress = 0.0f;
                    isGoingDown = false;
                    waitTime = Random.Range(1, 4);
                    yield return new WaitForSeconds(waitTime);
                }
            }
            else //lo mismo q hizo antes pero para arriba
            {

                rotationProgress += Time.deltaTime * upSpeed;

                transform.rotation = Quaternion.Lerp(endRotation, Quaternion.identity, rotationProgress);

                if (rotationProgress >= 1.0f)
                {
                    rotationProgress = 0.0f;
                    isGoingDown = true;
                    waitTime = Random.Range(1, 5);
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }
    }
}
