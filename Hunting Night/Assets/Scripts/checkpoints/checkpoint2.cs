using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint2 : MonoBehaviour
{
    public bool isCp2;
    checkpoint1 checkpoint1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player"))
        {
            isCp2 = true;
            print("cp2");
        }

        
    }
}
