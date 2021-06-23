using UnityEngine;

public class BumperControl : MonoBehaviour
{

    public Animator animator;

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.CompareTag("Player"))
        {
            animator.SetTrigger("Bumped_trig");
        }
    }
}
