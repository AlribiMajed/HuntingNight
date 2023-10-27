using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinsihLine : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
      
        if (other.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene("End");
            
        }
            
    }
}
