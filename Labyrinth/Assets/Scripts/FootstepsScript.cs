using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip FootStep1;
    public AudioClip FootStep2;
    public AudioClip FootStep3;
    public AudioClip FootStep4;

    private AudioClip[] AudioClips { get; set; }
    
    private AudioSource Audio { get; set; }
    private PlayerMovement CharMovement { get; set; }

    void Start()
    {
        AudioClips = new AudioClip[] { FootStep1, FootStep2, FootStep3, FootStep4 };
        Audio = gameObject.GetComponent<AudioSource>();
        CharMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //CharMovement = gameObject.GetComponent<PlayerMovement>();
        if (CharMovement.MoveVel.x != 0 || CharMovement.MoveVel.y != 0)
        {
            if (!Audio.isPlaying)
            {
                Audio.PlayOneShot(AudioClips[Random.Range(0, 3)]);
            }
        }
    }
}
