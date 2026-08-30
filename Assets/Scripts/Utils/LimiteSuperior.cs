using UnityEngine;

public class LimiteSuperior : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bear") || collision.CompareTag("Octopus") || 
        collision.CompareTag("Penguin") || collision.CompareTag("Rabbit"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb.linearVelocity.magnitude < 0.2f)
            {
                FindAnyObjectByType<GameManager>().Perder();
            }
        }
    }
}