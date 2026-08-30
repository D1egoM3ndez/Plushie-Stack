using UnityEngine;
using System.Collections;

public class FadeEntrada : MonoBehaviour
{
    public CanvasGroup fade;

    void Start()
    {
        fade.alpha = 1f;
        StartCoroutine(Aparecer());
    }

    IEnumerator Aparecer()
    {
        while (fade.alpha > 0)
        {
            fade.alpha -= Time.deltaTime;
            yield return null;
        }

        fade.alpha = 0f;
    }
}