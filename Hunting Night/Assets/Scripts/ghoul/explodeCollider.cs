using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explodeCollider : MonoBehaviour
{
    ghoul ghoul;
    PlayerController player;
    Animator animator;
    AudioManager audioManager;
    public float explodCooldown = 0.5f;
    void Start()
    {
        ghoul = gameObject.GetComponentInParent<ghoul>();
        animator = gameObject.GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void explode()
    {
        ghoul.explode();
        SceneManager.LoadScene("Scene0");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            ghoul.isExploding = true;
            player.isExploding = true;
            audioManager.PlaySFX(audioManager.explode);
            animator.Play("explode");
            Invoke("explode", explodCooldown);
            
        }
    }
}
