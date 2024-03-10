using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float Move;
    public float jump;
    public bool isOnGround;
    public bool isFacingRight;
    public Animator anim;
    public CoinManager cm;
    private AudioSource audioSource;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if((Move >= 0.1f || Move <= -0.1f) && isOnGround)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if((!isFacingRight && Move > 0f) || (isFacingRight && Move < 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            anim.SetBool("isJumping", false);
            audioSource.PlayOneShot(hitSound);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            anim.SetBool("isJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
