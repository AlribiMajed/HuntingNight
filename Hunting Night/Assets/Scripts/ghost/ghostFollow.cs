using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostFollow : MonoBehaviour
{
    public bool isTriggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D ohter)
    {
        if (ohter.gameObject.CompareTag("player"))
        {
            isTriggered = true;
        }
    }
}
