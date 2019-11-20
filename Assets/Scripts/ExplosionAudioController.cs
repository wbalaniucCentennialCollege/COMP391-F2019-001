using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudioController : MonoBehaviour
{
    public AudioClip[] clips;

    // Arrays
    // ========
    // - Zero-based index clips[0], clips[1]

    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();

        int randomNum = Random.Range(0, clips.Length);

        aSource.clip = clips[randomNum]; // Random num will be 0 up to clips.Length
        aSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
