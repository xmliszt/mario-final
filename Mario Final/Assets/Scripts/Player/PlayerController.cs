using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatVar playerPositionX;

    public FloatVar playerPositionY;

    public GameConstants constants;

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
        anim.SetTrigger("jump");
        anim.SetBool("grounded", false);
        rb.AddForce(Vector2.up * constants.jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (
            collision.gameObject.tag == "ground" ||
            collision.gameObject.tag == "brick"
        )
        {
            isGrounded = true;
            anim.SetBool("grounded", true);
        }
        if ((collision.gameObject.tag == "enemy") && isAlive)
        {
            // dead
            isAlive = false;
            GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        }
        if (collision.gameObject.tag == "enemy_top" && isAlive)
        {
            anim.SetTrigger("jump");
            rb
                .AddForce(Vector2.up * constants.jumpForce * 1.2f,
                ForceMode2D.Impulse);
            isGrounded = true;
        }
    }
}
