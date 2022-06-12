using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class AudioManager : MonoBehaviour
{
    public bool mainmenu;

    private List<FMOD.Studio.EventInstance> songs;

    bool muted;

    private void Start()
    {
        songs = new List<FMOD.Studio.EventInstance>();

        songs.Add(FMODUnity.RuntimeManager.CreateInstance("event:/MainMenuMusic"));
        songs.Add(FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic"));
        songs.Add(FMODUnity.RuntimeManager.CreateInstance("event:/GameOverMusic"));

        if (mainmenu)
        {
            StartMusic(0);
        }

        muted = false;
    }

    public void PlaySingleSound(string sound)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/FX/" + sound);
    }

    public void StartMusic(int song)
    {
        songs[song].start();
    }

    public void StopMusic(int song)
    {
        songs[song].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void Mute()
    {
        muted = !muted;
        FMODUnity.RuntimeManager.MuteAllEvents(muted);
    }

}
