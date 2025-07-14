using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float coyoteTime = 0.2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip runSound;
    public AudioClip rollingSound;
    public AudioClip squashSound;
    public AudioClip deathSound; 

    [Header("Effects")]
    public GameObject rollingEffectPrefab;
    public GameObject deathEffectPrefab; 

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private float dirX;
    private float coyoteCounter;
    private bool isGrounded;
    private bool isRolling;
    private bool isDead = false; 

    private Vector3 originalScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (!isDead)
        {            
            CameraController cam = Camera.main.GetComponent<CameraController>();
            if (cam != null && cam.IsPlayerOutOfView())
            {
                TriggerDeathEffects();
                isDead = true;
            }
        }
        dirX = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        HandleMovement();
        HandleJump();
        HandleAnimations();
    }

    void HandleMovement()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (dirX < 0) 
        { 
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coyoteCounter > 0 && !isRolling)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpSound);
            StartCoroutine(SquashAndStretch());
            coyoteCounter = 0f;

            CameraController cam = Camera.main.GetComponent<CameraController>();
            if (cam != null)
            {
                cam.ZoomInDuringJump();
            }
        }
    }

    void HandleAnimations()
    {
        anim.SetBool("isRunning", dirX > 0);
        anim.SetBool("isBack", dirX < 0);

        if (isGrounded && transform.localScale != originalScale)
        {
            transform.localScale = originalScale;

            CameraController cam = Camera.main.GetComponent<CameraController>();
            if (cam != null)
                cam.ResetZoom(); 
        }

        if (dirX != 0 && isGrounded && !audioSource.isPlaying)
            audioSource.PlayOneShot(runSound);
    }

    IEnumerator SquashAndStretch()
    {
        if (squashSound != null)
            audioSource.PlayOneShot(squashSound);

        transform.localScale = new Vector3(0.4f, 0.9f, 1);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(0.45f, 0.2f, 1);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpPad") && !isRolling)
        {
            isRolling = true;
            anim.SetTrigger("Rolling");
            audioSource.PlayOneShot(rollingSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.5f);

            
            if (rollingEffectPrefab != null)
                Instantiate(rollingEffectPrefab, transform.position, Quaternion.identity);

            CameraController cam = Camera.main.GetComponent<CameraController>();
            if (cam != null)
            {
                cam.ZoomInRolling();
                Invoke(nameof(ResetCameraRollingZoom), 0.5f);
            }

            Invoke(nameof(EndRolling), 0.8f);
        }

        if (collision.CompareTag("killzone"))
        {
            
            if (deathSound != null)
                audioSource.PlayOneShot(deathSound);

            
            if (deathEffectPrefab != null)
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

            
            spriteRenderer.enabled = false;
            rb.simulated = false;

            
            Invoke(nameof(GoToMenuScene), 1f);
        }
    }

    void EndRolling()
    {
        isRolling = false;
    }

    void ResetCameraRollingZoom()
    {
        CameraController cam = Camera.main.GetComponent<CameraController>();
        if (cam != null)
            cam.ResetZoomAfterRolling();
    }

    void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    
    void TriggerDeathEffects()
    {
        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);
        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        spriteRenderer.enabled = false;
        rb.simulated = false;
        Invoke(nameof(GoToMenuScene), 1f);
    }
}
