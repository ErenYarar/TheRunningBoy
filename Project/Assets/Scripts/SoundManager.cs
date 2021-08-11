using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerJumpSound, rainSound;
    static AudioSource audioSrc;
    
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip> ("playerJump");
        rainSound = Resources.Load<AudioClip> ("rain");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "rain":
                audioSrc.PlayOneShot(rainSound);
                break;
        }
    }
}
