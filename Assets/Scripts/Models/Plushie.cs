using UnityEngine;

public class Plushie : MonoBehaviour
{
    private bool apilado = false;

    public ParticleSystem chispas;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (apilado) return;

        Plushie otro = collision.gameObject.GetComponent<Plushie>();

        if (collision.gameObject.CompareTag("Suelo") || (otro != null && otro.apilado))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            // Efecto del peluche que está abajo sobre el peluche que cae
            if (collision.gameObject.CompareTag("Penguin"))
            {
                // Penguin: se desliza un poco al caer
                //Parte realizada por IA
                rb.AddForce(
                    new Vector2(Random.value < 0.5f ? -1.5f : 1.5f, 0f),
                    ForceMode2D.Impulse
                );
            }
            else if (collision.gameObject.CompareTag("Octopus"))
            {
                FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
                joint.connectedBody = collision.rigidbody;
            }

            //Comportamiento del peluche que esta cayendo al momento de tocar el suelo o un peluche apilado

            if(gameObject.CompareTag("Bear"))
            {
                apilado = true;
                GameManager gm = Object.FindAnyObjectByType<GameManager>();
                if (gm != null) gm.Apilar();
            }
            else if(gameObject.CompareTag("Octopus"))
            {
                if (rb != null) rb.linearVelocity = Vector2.zero;
                if (otro != null) gameObject.AddComponent<FixedJoint2D>().connectedBody = collision.rigidbody;

                apilado = true;
                GameManager gm = Object.FindAnyObjectByType<GameManager>();
                if (gm != null) gm.Apilar();
            }
            else if(gameObject.CompareTag("Penguin"))
            {
                if (rb != null) rb.AddForce(new Vector2(Random.value < 0.5f ? -2f : 2f, 0f), ForceMode2D.Impulse);

                apilado = true;
                GameManager gm = Object.FindAnyObjectByType<GameManager>();
                if (gm != null) gm.Apilar();
            }
            else if(gameObject.CompareTag("Rabbit"))
            {
                if (rb != null) rb.AddForce(new Vector2(Random.Range(-1f, 1f), 3f), ForceMode2D.Impulse);

                apilado = true;
                GameManager gm = Object.FindAnyObjectByType<GameManager>();
                if (gm != null) gm.Apilar();
            }

            chispas.Play();
        }
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            GameManager gm = Object.FindAnyObjectByType<GameManager>();
            if (gm != null) gm.Perder();
        }
    }
}
