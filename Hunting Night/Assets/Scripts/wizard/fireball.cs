using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fireball : MonoBehaviour
{

    [SerializeField] float speed = 5;
    Rigidbody2D rb;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2.5f);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("bullet"))
            Destroy(gameObject);
        
        if (other.gameObject.CompareTag("player"))
            SceneManager.LoadScene("Scene0");
        
    }
}
