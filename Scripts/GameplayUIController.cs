using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{

    public void HomeButton()
    {
        OnHomeButtonClicked();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void OnHomeButtonClicked()
    {
        // Find the current MusicManager instance
        MusicManager musicManager = FindObjectOfType<MusicManager>();

        if (musicManager != null)
        {
            // Destroy the MusicManager instance
            Destroy(musicManager.gameObject);
        }
    }
}