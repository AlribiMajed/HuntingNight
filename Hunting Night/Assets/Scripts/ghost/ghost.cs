using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ghost : MonoBehaviour
{
    [SerializeField] float health = 2;
    Transform player;
    bool isTriggered = false;
    bool facingRight = false;
    [SerializeField] float speed = 2f;
    bool isDying = false;
    Animator animator;
    AudioManager audioManager;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        if(isTriggered)
        {
            follow();
        }
        
    }
    void follow()
    {
        if(!isDying)
        transform.position = Vector2.MoveTowards(transform.position, player.position,speed * Time.deltaTime );
    }
    void death()
    {
        Destroy(gameObject);
    }
    void flip()
    {
        if (transform.position.x - player.position.x < 0 && !facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);

        }
        else if (transform.position.x - player.position.x > 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene("Scene0");
        }
        if (other.gameObject.CompareTag("bullet") && health>0)
        {
            health--;
        }
        else if(other.gameObject.CompareTag("bullet") && health == 0 || other.gameObject.CompareTag("spikes"))
        {
            isDying = true;
            audioManager.PlaySFX(audioManager.ghostDeath);
            animator.Play("death");
            Invoke("death", 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isTriggered = true;
            audioManager.PlaySFX(audioManager.detected);
        }

            
    }
}
