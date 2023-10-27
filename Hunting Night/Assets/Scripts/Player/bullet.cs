using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    [SerializeField]private float speed = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * transform.right;
        Destroy(gameObject, 0.21f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {       
        Destroy(gameObject);
     
    }
}
