using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    [SerializeField] float Yoffset = 5f;

    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,Yoffset,transform.position.z);
    }
}
