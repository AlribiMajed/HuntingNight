using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    PlayerShooting PlayerShooting;
    
    [SerializeField]private float moveSpeed = 10f;
    [SerializeField]private float jumpForce = 60f;
    [SerializeField] private float dashForce = 50f;

    public bool isJumping = false;
    bool facingRight = true;
    private float moveHorizontal;
    private float moveVertical;
    float jump;
    bool isDashing = false;
    public bool isExploding = false;

    AudioManager audioManager;




    void Start()
    {
        UnityEngine.Cursor.visible = false;

        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        PlayerShooting = GetComponent<PlayerShooting>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();


    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        jump = Input.GetAxisRaw("Jump");
        if (Input.GetButtonDown("dash") && !isDashing)
            dash();
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("menu");
        }
        
    }
    private void FixedUpdate()
    {
        if(!isExploding)
        {
        movement(); 
        jumping();
        movementDown();
        }
        
        
        
    }
    void movement()
    {
        if(moveHorizontal >0 || moveHorizontal <0)
        {
           
         //flipping the character       
          if(moveHorizontal < 0 && facingRight)
            {
                flip();
            }
          if(moveHorizontal > 0 && !facingRight)
            {
                flip();
            }
            if (!PlayerShooting.isShooting)
            {
             rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
             if(!isJumping && !isExploding)
             animator.Play("run");
                
                
            }
         
        }
        if (moveHorizontal == 0 && !isJumping && !PlayerShooting.isShooting)
            animator.Play("idle");
    }
 
    void jumping()
    {
        if (jump >0 && !isJumping)
        {
           rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            audioManager.PlaySFX(audioManager.jump);
            animator.Play("jump");
        }
    }
    private void movementDown()
    {
        
            if(moveVertical <0 && isJumping)
        {
            rb.AddForce(new Vector2(0f,moveVertical * moveSpeed), ForceMode2D.Impulse);
            animator.Play("fall");
        }
        if (rb.velocity.y <0 && isJumping)
            animator.Play("fall");
            
       
    }
    void dash()
    {
        
            rb.AddForce(new Vector2(dashForce * moveHorizontal, 0),ForceMode2D.Impulse);

        if(moveHorizontal!=0)
        audioManager.PlaySFX(audioManager.dash);

        isDashing = true;
        rb.gravityScale = 0f;
        Invoke("gravityCooldown", 0.2f);
        Invoke("dashCooldown", 0.7f);
        

    }
    void gravityCooldown()
    {
        rb.gravityScale = 6f;
    }
    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    void dashCooldown()
    {
        isDashing = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Platform") 
        {
            audioManager.PlaySFX(audioManager.hitPlatfrom);
            isJumping = false;
            rb.gravityScale = 6f;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("Scene0");
        }

    }
}
