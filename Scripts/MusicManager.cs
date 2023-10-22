using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;
    public AudioSource backgroundMusic;


    void Start()
    {
        // Check if the MusicManager instance already exists.
        if (musicManagerInstance != null)
        {
            // Destroy the current MusicManager instance.
            Destroy(gameObject);
            return;
        }

        // Set the MusicManager instance.
        musicManagerInstance = this;

        // Mark the MusicManager instance as DontDestroyOnLoad.
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeBGM(AudioClip music)
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
}
