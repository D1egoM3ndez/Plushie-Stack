using UnityEngine;

public class ZonaAlerta : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bear") || collision.CompareTag("Octopus") ||
            collision.CompareTag("Penguin") || collision.CompareTag("Rabbit"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb.linearVelocity.magnitude < 0.2f)
            {
                collision.GetComponent<SpriteRenderer>().color = new Color(1f, 0.55f, 0.55f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bear") || collision.CompareTag("Octopus") ||
            collision.CompareTag("Penguin") || collision.CompareTag("Rabbit"))
        {
            collision.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}