using JetBrains.Annotations;
using System;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip driveSound;
    [SerializeField] private AudioClip collectibleSound;
    [SerializeField] private AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        // ----- if sound manager doesn't exist, create it -----
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // ----- if its created than destroy the instance -----
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartEngineSound()
    {
        audioSource.clip = driveSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopEngineSound()
    {
        audioSource.Stop();
    }

    public void PlayCollectibleSounds()
    {
        audioSource.PlayOneShot(collectibleSound);
    }

    public bool IsEnginePlaying()
    {
        // ---- checks if audio source is currently playing something ----
        bool isPlaying = audioSource.isPlaying;

        // ---- checks if that something is our engine clip (not collectible sound) ----
        bool isEngineClip = audioSource.clip == driveSound;

        // ---- Both must be true ----
        return isPlaying && isEngineClip;
    }
}
