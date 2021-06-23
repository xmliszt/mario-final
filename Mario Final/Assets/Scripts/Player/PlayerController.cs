using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Sound Events Binding")]
    public GameEvent OnBumpPlaySound;

    public GameEvent OnJumpPlaySound;

    public GameEvent OnStompPlaySound;

    public GameEvent OnDiePlaySound;

    public GameEvent OnCoinPlaySound;

    [Header("Other Events Binding")]
    public LocationGameEvent OnMarioDeath;

    public IntegerGameEvent OnAddScore;

    [Header("Variable Binding")]
    public FloatVar playerPositionX;

    public FloatVar playerPositionY;

    [Header("Game Constants")]
    public GameConstants constants;

    [Header("Components")]
    public Animator anim;

    private bool isAlive = true;

    private float horizontalInput;

    private bool isGrounded = false;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPositionX.Set(transform.position.x);
        playerPositionY.Set(transform.position.y);
    }

    void Update()
    {
        if (isAlive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            transform
                .Translate(Vector2.right *
                Time.deltaTime *
                horizontalInput *
                constants.moveSpeed);

            // Update player position var
            playerPositionX.Set(transform.position.x);
            playerPositionY.Set(transform.position.y);

            if (
                (
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.W)
                ) &&
                isGrounded
            )
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        OnJumpPlaySound.Raise();
        anim.SetTrigger("jump");
        anim.SetBool("grounded", false);
        rb.AddForce(Vector2.up * constants.jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground") || other.collider.CompareTag("brick"))
        {
            isGrounded = true;
            anim.SetBool("grounded", true);
        }
        if ((other.collider.CompareTag("enemy")) && isAlive)
        {
            StartCoroutine(CheckDeath(other.gameObject));
        }
        if (other.collider.CompareTag("enemy_top") && isAlive)
        {
            OnStompPlaySound.Raise();
            anim.SetTrigger("jump");
            rb
                .AddForce(Vector2.up * constants.jumpForce * 1.2f,
                ForceMode2D.Impulse);
            isGrounded = true;
        }
        if (other.collider.CompareTag("bumper"))
        {
            OnBumpPlaySound.Raise();
        }
    }

    // Wait for a very short while for enemy to update
    // Prevent accident death upon stomping on Gomba
    IEnumerator CheckDeath(GameObject enemy)
    {
        yield return new WaitForSeconds(0.01f);
        if (!enemy.CompareTag("dead"))
        {
            isAlive = false;
            OnDiePlaySound.Raise();
            OnMarioDeath.Raise(transform.position);
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            OnCoinPlaySound.Raise();
            OnAddScore.Raise(constants.coinCollected);
        }
    }
}
