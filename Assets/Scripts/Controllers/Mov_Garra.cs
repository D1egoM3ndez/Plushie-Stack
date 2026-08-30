using UnityEngine;
using UnityEngine.InputSystem;

public class Mov_Garra : MonoBehaviour
{
    public float velocidad = 5f;

    public GameObject plushie_bear;
    public GameObject plushie_octopus;
    public GameObject plushie_penguin;
    public GameObject plushie_rabbit;

    GameObject plushieActual;

    public Animator animator;

    float tiempoEspera = 0f;

    void Update()
    {
        float x = 0f;

        if (Keyboard.current.leftArrowKey.isPressed) x -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) x += 1f;

        transform.position += new Vector3(x, 0f, 0f) * velocidad * Time.deltaTime;

        tiempoEspera -= Time.deltaTime;

        // Genera un nuevo peluche
        if (plushieActual == null && tiempoEspera <= 0)
        {
            GameObject plushiePrefab;

            float randomValue = Random.value;

            if (randomValue < 0.40f) plushiePrefab = plushie_bear;
            else if (randomValue < 0.65f) plushiePrefab = plushie_octopus;
            else if (randomValue < 0.85f) plushiePrefab = plushie_rabbit;
            else plushiePrefab = plushie_penguin;

            Vector3 spawnPos = new Vector3(
                transform.position.x,
                transform.position.y - 1,
                0f
            );

            plushieActual = Instantiate(
                plushiePrefab,
                spawnPos,
                Quaternion.identity
            );

            // Parte generada por IA: hace que el peluche sea hijo de la garra y desactiva su simulación de física
            plushieActual.transform.parent = transform;
            plushieActual.GetComponent<Rigidbody2D>().simulated = false;

            animator.SetTrigger("Cerrar");
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && plushieActual != null)
        {
            animator.SetTrigger("Abrir");

            plushieActual.transform.parent = null;

            plushieActual.GetComponent<Rigidbody2D>().simulated = true;

            plushieActual = null;

            tiempoEspera = 0.5f;
        }
    }
}