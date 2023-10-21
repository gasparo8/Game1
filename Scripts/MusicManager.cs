using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;


    void Start()
    {
        // Check if the current scene is "Game1Level5".
        if (SceneManager.GetActiveScene().name == "Game1Level5")
        {
            // Destroy the MusicManager instance.
            Destroy(gameObject);
        }
    }

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
