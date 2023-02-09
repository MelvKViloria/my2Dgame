using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class playermovement : MonoBehaviour
{
    public Animator animator;
    public float horizontal;
    float speed = 8f;
    float jumpingPower = 16f;
    bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    
    [SerializeField] private AudioSource jump;
    
    

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("speed",Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump.Play();
            
            
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpingPower), ForceMode2D.Impulse);
        }

        Flip();
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
 private void OnCollisionEnter2D(Collision2D other)
 {
    if (other.gameObject.tag == "enemy")
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 }

}