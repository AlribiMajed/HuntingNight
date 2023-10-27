using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCollider : MonoBehaviour
{
    ghoul ghoul;
    void Start()
    {
        ghoul = GameObject.Find("ghoul").GetComponent<ghoul>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        { 
            gameObject.SetActive(false);
            
        }
    }
}
