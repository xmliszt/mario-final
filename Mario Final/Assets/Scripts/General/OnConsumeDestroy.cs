using UnityEngine;

public class OnConsumeDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy (gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Destroy (gameObject);
        }
    }
}
