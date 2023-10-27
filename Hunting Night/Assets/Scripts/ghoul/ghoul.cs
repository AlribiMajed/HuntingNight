using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ghoul : MonoBehaviour
{
    [SerializeField] int health = 1;
    public bool isFollowing = false;
    bool facingRight = false;
    bool dying = false;
    public bool isExploding = false;
    [SerializeField] float speed = 5f;
    private Transform player;
    Animator animator;
    AudioManager audioManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
            follow();
        flip();

    }
    public void follow()
    {
        if(!isExploding && !dying)
        {
            
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.position.x,transform.position.y,transform.position.z),speed * Time.deltaTime);
            animator.Play("run");
        }
  
        

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
    public void explode()
    {
        audioManager.PlaySFX(audioManager.explode);
        cameraShake.Instance.CameraShake(10f, 0.5f);
        Destroy(gameObject);
    }
    void death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("bullet") && health>0)
        {
            health--;   
        }
        else if(other.gameObject.CompareTag("bullet") && health <= 0 || other.gameObject.CompareTag("spikes"))
        {
            animator.Play("death");
            dying = true;
            audioManager.PlaySFX(audioManager.explode);
            Invoke("death", 0.5f);
            
        }
       
            
     

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowing = true;
            audioManager.PlaySFX(audioManager.roar);
        }
        
       
            
    }
}
