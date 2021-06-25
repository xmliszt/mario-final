using UnityEngine;

public class OnConsumeDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("death") || collision.CompareTag("Player"))
        {
            Destroy (gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy (gameObject);
        }
    }
}
