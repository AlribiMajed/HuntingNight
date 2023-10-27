using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    [SerializeField]private float health = 2;
    [SerializeField] private float speed = 10f;
    GameObject followCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool rised = false;
    bool following = false;
    bool facingRight = false;
    bool dying = false;
    [SerializeField]float riseCooldown = 2f;
    private Transform player;
    CapsuleCollider2D capsuleCollider;
    AudioManager audioManager;
    void Start()
    {
        
        followCollider = transform.Find("followCollider").gameObject;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("player").transform;

        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;

        spriteRenderer.enabled = false;
        followCollider.SetActive(true);

        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rised)
        {
            capsuleCollider.enabled = true;
            followCollider.SetActive(true);
        }
           if(following)
        {
            follow();
        }
        flip();

    }
    void follow()
    {
        if(!dying)
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
    void RiseCooldown()
    {
        gameObject.tag = "enemy";
        rised = true;
        following = true;
        if(!dying)
        animator.Play("run");
    }
    void flip()
    {
        if(transform.position.x - player.position.x < 0 && !facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
            
        }
        else if(transform.position.x - player.position.x > 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0,180,0);
        }
    }
    void death()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && !rised)
        {
            rised = true;
            audioManager.PlaySFX(audioManager.rise);
            animator.Play("rise");
            spriteRenderer.enabled = true;

        }
        if(other.gameObject.CompareTag("player")&& rised && !dying)
        {
            Invoke("RiseCooldown", riseCooldown);

        }  
            
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet") && health > 0 && rised)
        {
            audioManager.PlaySFX(audioManager.hit);
            health--;
        }
        else if(other.gameObject.CompareTag("bullet") && health == 0 && rised || other.gameObject.CompareTag("spikes"))
        {
            audioManager.PlaySFX(audioManager.death);
            animator.Play("death");
            dying = true;
            Invoke("death", 0.5f);
        }
            
    }

}
