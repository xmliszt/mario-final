using System.Collections;
using UnityEngine;

public class SquashController : MonoBehaviour
{
    public IntegerGameEvent OnAddScore;

    public GameConstants constants;

    public GameObject gomba;

    public Animator animator;

    private bool dead = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("death"))
        {
            Squash();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Squash();
        }
    }

    public void Squash()
    {
        if (!dead)
        {
            dead = true;
            OnAddScore.Raise(constants.gombaKilled);
            gomba.tag = "dead";
            animator.SetTrigger("Dead_trig");
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy (gomba);
    }
}
