using UnityEngine;
using System.Collections;

public class Audioplayer : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    private AudioSource audioSource;

    private bool isAudioPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision");

     
        if (collision.gameObject.CompareTag("fence") && !isAudioPlaying)
        {
            PlayRandomCollisionSound();
        }
    }

    void PlayRandomCollisionSound()
    {
        if (collisionSounds.Length > 0)
        {
            
            AudioClip randomClip = collisionSounds[Random.Range(0, collisionSounds.Length)];

            
            audioSource.clip = randomClip;

            audioSource.Play();

            isAudioPlaying = true;

            StartCoroutine(ResetAudioFlag(randomClip.length));
        }
    }

    IEnumerator ResetAudioFlag(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAudioPlaying = false;
    }
}
