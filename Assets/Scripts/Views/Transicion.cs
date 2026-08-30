using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transicion : MonoBehaviour
{
    public CanvasGroup fade;

    public void IrAInstrucciones()
    {
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        while (fade.alpha < 1)
        {
            fade.alpha += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Instrucciones");
    }
}