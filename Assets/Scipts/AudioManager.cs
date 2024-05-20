using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] private AudioSource audioSource;

    public void PlaySoundEffect(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
}
