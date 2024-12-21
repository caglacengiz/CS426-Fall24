using System.Collections;
using UnityEngine;

public class PlayNoise : MonoBehaviour
{
    public int state;
    public StateMachine stateMachine;
    public AudioSource noise;

    private bool didPlay = false;
    private bool goingToPlay = false;
    public bool isPlaying = false;



    void Start()
    {
        if (noise == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }else{
            noise.Play();
            noise.Stop();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")) // If player enters trigger
        {
            if (stateMachine.state == state && !didPlay)
            {
            
                stateMachine.door1Lock = true;
                didPlay = true;
                goingToPlay = true;
            }
        }
    }

    void Update()
    {
        if (goingToPlay)
        {
            if (noise == null)
            {
                Debug.LogError("AudioSource is null. Assign it in the Inspector.");
                return;
            }

            if (!isPlaying)
            {
                noise.Play();
                isPlaying = true;
            }
            else
            {
                if (!noise.isPlaying)
                {
                
                    goingToPlay = false;
                    isPlaying = false;
                    stateMachine.door1Lock = false; // Unlock the door after sound finishes
                }
            }
        }
    }
}
