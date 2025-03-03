using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioSource effects;
    private AudioSource music;

    public AudioClip coin;
    public AudioClip jump;

    bool muted;

    public static SoundManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        music = GetComponent<AudioSource>(); 
    }

    public void ToggleMuted()
    {
        muted = !muted;
        music.mute = muted;
    }

    public void PlayJump()
    {
        if (muted) return;
        effects.PlayOneShot(jump, 1);
    }
    public void PlayCoin()
    {
        if (muted) return;
        effects.PlayOneShot(coin, 1);
    }

    public bool GetMuted()
    {
        return muted;
    }

}
