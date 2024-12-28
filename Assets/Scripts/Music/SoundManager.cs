using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip jumpClip;
    public AudioClip backgroundMusicClip;
    
    // This method will be used for playing sound clips
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); // Plays the provided sound clip
    }

    // Play jump sound (for player jumping)
    public void PlayJumpSound()
    {
        PlaySound(jumpClip); // Play the jump sound
    }
    public void PlayBackgroundMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusicClip;
            audioSource.loop = true; // Make the background music loop
           
            audioSource.Play();
            
        }
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PauseMusic()
    {
        audioSource.Pause();
    }
    public void ResumeMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Resume the music if it was paused
        }
    }
}
