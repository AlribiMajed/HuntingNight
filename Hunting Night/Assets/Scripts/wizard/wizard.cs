using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class wizard : MonoBehaviour
{
    [SerializeField] float health = 1;
    public GameObject fireball;
    public Transform fireballPos;
    bool isDying = false;
    [SerializeField] private float FireCooldown = 1f;
    Animator animator;
    bool isShooting = true;
    bool isTriggered = false;
    AudioManager audioManager;
    

    private void Start()
    {
        Invoke("cooldown", FireCooldown);
        animator = GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    private void FixedUpdate()
    {
        if(isTriggered)
        {
            shoot();
        }
    }


    public void shoot()
    {
        if(!isShooting && !isDying)
        {
            audioManager.PlaySFX(audioManager.fireBall);
        Instantiate(fireball,fireballPos.position,fireballPos.rotation);
            isShooting = true;
            animator.Play("shoot");
            Invoke("cooldown", FireCooldown);
            
        }
        
    }
    void cooldown()
    {
        isShooting=false;
    }
    void death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet") && health>0)
        {
            health--;
        }
        else if (other.gameObject.CompareTag("bullet") && health == 0)
        {
            isDying = true;
            audioManager.PlaySFX(audioManager.wizardDeath);
            animator.Play("death");
            Invoke("death", 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isTriggered = true;
        }
    }

}
