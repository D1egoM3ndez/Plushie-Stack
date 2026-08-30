using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int meta = 25;
    public int apilados = 0;
    private bool terminada = false;

    public GameObject pantallaPausa;
    public GameObject pantallaVictoria;
    public GameObject pantallaDerrota;

    public TMP_Text textoContador;

    public void Apilar()
    {
        if (terminada) return;

        apilados++;

        textoContador.text = apilados + " / " + meta + " apilados";

        if (apilados == meta)
        {
            InvokeRepeating("RevisarVictoria", 0.5f, 0.2f);
        }
    }

    //Parte realizada por IA, me ayudo a verificar si todos los peluches están quietos antes de declarar la victoria
    void RevisarVictoria()
    {
        Plushie[] peluches = FindObjectsByType<Plushie>();

        foreach (Plushie peluche in peluches)
        {
            Rigidbody2D rb = peluche.GetComponent<Rigidbody2D>();

            if (rb != null && rb.simulated && rb.linearVelocity.magnitude > 0.1f)
            {
                return;
            }
        }

        CancelInvoke("RevisarVictoria");
        Ganar();
    }

    //Todo el siguiente bloque de funciones fueron sacadas de laboratorios y clases pasadas, obviamente adaptados 
    //a la logica de este juego
    public void PausarJuego()
    {
        pantallaPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuarJuego()
    {
        pantallaPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Ganar()
    {
        if (terminada) return;

        terminada = true;
        pantallaVictoria.SetActive(true);
    }

    public void Perder()
    {
        if (terminada) return;

        terminada = true;
        pantallaDerrota.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}