using System.Collections;
using UnityEngine;

public class SquashController : MonoBehaviour
{
    public GameObject gomba;
    public Animator animator;
    
    private bool dead = false;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player") && !dead) {
            animator.SetTrigger("Dead_trig");
            gomba.tag = "dead";
            dead = true;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(0.4f);
        Destroy(gomba);
    }
}
