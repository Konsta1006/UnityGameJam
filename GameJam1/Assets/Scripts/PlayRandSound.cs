using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandSound : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();

    public void PlayRandomSound()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Count)];
            GetComponent<AudioSource>().Play();
        }
        
    }
}
