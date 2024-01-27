using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collosion");
        
        if (collision.gameObject.CompareTag("fence"))
        {
            
            PlayRandomCollisionSound();
        }
    }

    void PlayRandomCollisionSound()
    {
        if (collisionSounds.Length > 0)
        {
            // Select a random audio clip
            AudioClip randomClip = collisionSounds[Random.Range(0, collisionSounds.Length)];

            // Assign the selected clip to the AudioSource
            audioSource.clip = randomClip;

            // Play the collision sound
            audioSource.Play();
        }
    }
}
