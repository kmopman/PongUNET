using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    /*
     * RESPONSIBILITY: Plays sounds.
     */


    [SerializeField] private AudioSource[] _soundEffects; // An array that holds AudioSources.

    /*
     * 0 = Ball hits Player
     * 1 = Ball hits Collider
     * 2 = Error
     */


    public void PlaySound(int fx)
    {
        _soundEffects[fx].Play();
    }

    /*
     * Function that can be called in other classes.
     * Call this function and give it a parameter to play a sound.
     */
}
