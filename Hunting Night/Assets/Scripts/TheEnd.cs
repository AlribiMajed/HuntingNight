using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
        
    }
    private void Start()
    {
        UnityEngine.Cursor.visible = true;
    }
}
