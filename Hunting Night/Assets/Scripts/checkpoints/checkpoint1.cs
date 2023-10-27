using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkpoint1 : MonoBehaviour
{
    public bool isCp1;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player"))
        {
            isCp1 = true;
            print("cp1");
        }

    }
}
