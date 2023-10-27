using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private Animator animator;
    PlayerController PlayerController;

    public bool isShooting;
    [SerializeField]private float coolDownTime;

    AudioManager audioManager;
  
    

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        PlayerController = GetComponent<PlayerController>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (!PlayerController.isJumping)

            animator.Play("shoot");
            shoot();
            
            
        }
       
    }
    void shoot()
    {
        if (!isShooting)
        {
            cameraShake.Instance.CameraShake(8f, 0f);
            audioManager.PlaySFX(audioManager.fire);
        Instantiate(bullet,firePoint.position,firePoint.rotation);
        isShooting = true;
        Invoke("coolDown", coolDownTime);
        }
       
    }
    void coolDown()
    {
        isShooting = false;
    }
}
