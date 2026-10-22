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
    public void PlayDriveSound()
    {
        audioSource.PlayOneShot(driveSound);
    }

    public void PlayCollectibleSounds()
    {
        audioSource.PlayOneShot(collectibleSound);
    }
}
