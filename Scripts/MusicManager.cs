using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;
    public AudioSource backgroundMusic;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeBGM(AudioClip music)
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
}

/*
void Awake()
{
    DontDestroyOnLoad(this);

    if (musicManagerInstance == null)
    {
        musicManagerInstance = this;
    }

    else
    {
        Destroy(gameObject);
    }
}
}
*/