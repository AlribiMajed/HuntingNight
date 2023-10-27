using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource SFXSource;
    
    public AudioClip soundtrack;
    public AudioClip boss;
 
    [Header("player")]
    public AudioClip fire;
    public AudioClip jump;
    public AudioClip hitPlatfrom;
    public AudioClip footstep;
    public AudioClip dash;
    [Header("skeleton")]
    public AudioClip hit;
    public AudioClip rise;
    public AudioClip death;
    [Header("ghoul")]
    public AudioClip roar;
    public AudioClip explode;
    [Header("ghost")]
    public AudioClip detected;
    public AudioClip ghostDeath;
    [Header("wizard")]
    public AudioClip fireBall;
    public AudioClip wizardDeath;

 

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Scene0")
        {
        musicSource.clip = soundtrack;
        musicSource.Play();
        }
        else if(SceneManager.GetActiveScene().name == "boss")
        {
            musicSource.clip = boss;
            musicSource.Play();
        }
       
        

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
 

}
