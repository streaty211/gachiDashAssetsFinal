using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager snd;
    private AudioSource audioSrc;
    private AudioClip[] deathSounds;
    private int randomDeath;
    // Start is called before the first frame update
    void Start()
    {
        snd = this;
        audioSrc = GetComponent<AudioSource>();
        deathSounds = Resources.LoadAll<AudioClip>("DeathSounds");
    }

    public void PlayDeathSounds()
    {
        randomDeath = Random.Range(0, 5);
        audioSrc.PlayOneShot(deathSounds[randomDeath]);
    }
}
