using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 
    private void Start()
    {
        UnityEngine.Cursor.visible = true;
      
    }
    public void Play()
    {
        SceneManager.LoadScene("Scene0");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

 
}
