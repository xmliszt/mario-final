using UnityEngine;

public class GombaHandler : MonoBehaviour
{
    private bool playerInvincible = false;

    public void OnPlayerTurnInvincible()
    {
        gameObject.tag = "enemy_top";
        playerInvincible = true;
    }

    public void OnPlayerTurnOffInvincible()
    {
        gameObject.tag = "enemy";
        playerInvincible = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && playerInvincible)
        {
            GetComponentInChildren<SquashController>().Squash();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("death"))
        {
            Destroy(gameObject);
        }
    }
}
