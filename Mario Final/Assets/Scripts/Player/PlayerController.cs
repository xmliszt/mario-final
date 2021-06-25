using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [Header("Sound Events Binding")]
    public GameEvent OnBumpPlaySound;

    public GameEvent OnJumpPlaySound;

    public GameEvent OnStompPlaySound;

    public GameEvent OnDiePlaySound;

    public GameEvent OnCoinPlaySound;

    [Header("Other Events Binding")]

    public GameEvent OnGameOver;
    public GameEvent OnPlayerInvincible;

    public GameEvent OnPlayerOffInvincible;

    public GameEvent OnUseItem;

    public LocationGameEvent OnMarioDeath;

    public IntegerGameEvent OnAddScore;

    [Header("Variable Binding")]
    public FloatVar playerPositionX;

    public FloatVar playerPositionY;

    [Header("Game Constants")]
    public GameConstants constants;

    [Header("Components")]
    public Animator anim;

    public Light2D _light;

    private bool isAlive = true;

    private float horizontalInput;

    private float additionalSpeed = 0; // from booster

    private float additionalForce = 0; // from booster

    private bool isGrounded = false;

    private bool invincible = false;
    private bool effectInUse = false;

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
                (constants.moveSpeed + additionalSpeed));

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!effectInUse)
                {
                    effectInUse = true;
                    OnUseItem.Raise();
                }
            }
        }
    }

    private void Jump()
    {
        OnJumpPlaySound.Raise();
        anim.SetTrigger("jump");
        anim.SetBool("grounded", false);
        rb
            .AddForce(Vector2.up * (constants.jumpForce + additionalForce),
            ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (
            other.collider.CompareTag("ground") ||
            other.collider.CompareTag("brick")
        )
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
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        OnDiePlaySound.Raise();
        OnMarioDeath.Raise(transform.position);
        OnGameOver.Raise();
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            OnCoinPlaySound.Raise();
            OnAddScore.Raise(constants.coinCollected);
        }
        if (other.CompareTag("fireball") && !invincible)
        {
            Die();
        }
        if (other.CompareTag("death"))
        {
            Die();
        }
    }

    public void OnGoldenMushroomUsed()
    {
        invincible = true;
        OnPlayerInvincible.Raise();
        transform.localScale *= constants.goldenMushroomSizeUpMultiplier;
        _light.enabled = true;
        _light.intensity = constants.goldenMushroomEffectIntensity;
        _light.color = constants.goldenMushroomEffectColor;
        StartCoroutine(TurnOffInvincible());
    }

    IEnumerator TurnOffInvincible()
    {
        yield return new WaitForSeconds(constants.goldenMushroomEffectDuration);
        invincible = false;
        OnPlayerOffInvincible.Raise();
        transform.localScale /= constants.goldenMushroomSizeUpMultiplier;
        _light.enabled = false;
        effectInUse = false;
    }

    public void OnSpeedMushroomUsed()
    {
        additionalSpeed = constants.speedMushroomGainSpeed;
        _light.enabled = true;
        _light.intensity = constants.speedMushroomEffectIntensity;
        _light.color = constants.speedMushroomEffectColor;
        StartCoroutine(TurnOffSpeedGain());
    }

    IEnumerator TurnOffSpeedGain()
    {
        yield return new WaitForSeconds(constants.speedMushroomEffectDuration);
        additionalSpeed = 0;
        _light.enabled = false;
        effectInUse = false;
    }

    public void OnJumperMushroomUsed()
    {
        additionalForce = constants.jumperMushroomJumpForceGain;
        _light.enabled = true;
        _light.intensity = constants.jumperMushroomEffectIntensity;
        _light.color = constants.jumperMushroomEffectColor;
        StartCoroutine(TurnOffJumpGain());
    }

    IEnumerator TurnOffJumpGain()
    {
        yield return new WaitForSeconds(constants.jumperMushroomEffectDuration);
        additionalForce = 0;
        _light.enabled = false;
        effectInUse = false;
    }
}
