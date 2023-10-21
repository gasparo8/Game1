using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip newTrack;
    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();

        if(newTrack != null)
        musicManager.ChangeBGM(newTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
