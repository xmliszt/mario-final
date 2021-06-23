using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameConstants constants;
    private bool isAlive;
    private bool isInvincible;
    private Animator anim;
    private float horizontalInput;
    private bool isGrounded;
    
    private Rigidbody2D rb;
    private SoundManager sm;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        isInvincible = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sm = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isAlive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            anim.SetBool("Grounded_b", isGrounded);
            anim.SetFloat("Speed_f", Mathf.Abs(horizontalInput));
            if (horizontalInput > 0)
            {
                // move right
                transform.localScale = new Vector2(1, 1);
                transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * constants.moveSpeed);
            }
            else if (horizontalInput < 0)
            {
                // move left
                transform.localScale = new Vector2(-1, 1);
                transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * constants.moveSpeed);
            }
            else
            {
                // idle
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("Running_b", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("Running_b", false);
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
            {
                // mario jump
                Jump();
            }
        }
    }

    private void Jump()
    {
        sm.PlayJump();
        anim.SetTrigger("Jump_trig");
        rb.AddForce(Vector2.up * constants.jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "brick")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "bumper")
        {
            sm.PlayBump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "enemy" || collision.gameObject.tag == "firewall") && isAlive && !isInvincible)
        {
            // dead
            isAlive = false;
            GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Foreground";
            anim.SetTrigger("Dead_trig");
            anim.SetBool("Dead_b", true);
            sm.PauseMain();
            sm.StopSource();
            sm.PlayDie();
            // gameover
        }
        if (collision.gameObject.tag == "coin")
        {
            scoreManager.AddScore(1);
            sm.PlayCoin();
        }
        if (collision.gameObject.tag == "mushroom")
        {
            // collect item
            CancelInvoke();
            anim.SetTrigger("Invincible_trig");
            anim.SetBool("Invincible_b", true);
            isInvincible = true;
            Invoke("OffInvincible", 5);
        }
        if (isInvincible && collision.gameObject.tag == "enemy")
        {
            sm.PlayStomp();
        }
        if (collision.gameObject.tag == "enemy_top" && isAlive)
        {
            sm.PlayStomp();
            anim.SetTrigger("Jump_trig");
            rb.AddForce(Vector2.up * constants.jumpForce * 1.2f, ForceMode2D.Impulse);
            isGrounded = true;
        }
    }

    private void OffInvincible()
    {
        isInvincible = false;
        anim.SetBool("Invincible_b", false);
        anim.SetTrigger("OffInvincible_trig");
    }
}
