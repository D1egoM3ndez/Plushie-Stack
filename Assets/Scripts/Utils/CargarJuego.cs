using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargaJuego : MonoBehaviour
{
    public CanvasGroup fade;

    void Start()
    {
        StartCoroutine(Cargar());
    }

    IEnumerator Cargar()
    {
        yield return new WaitForSeconds(4f);

        while (fade.alpha < 1)
        {
            fade.alpha += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Juego");
    }
}