using System.Collections;
using UnityEngine;

public class PlayBesik : MonoBehaviour
{
    public int state;
    public StateMachine stateMachine;
    public AudioSource noise;
    public AudioSource noise2;
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
            noise2.Play();
            noise2.Stop();
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
            if (noise == null||noise2==null)
            {
                Debug.LogError("AudioSource is null. Assign it in the Inspector.");
                return;
            }

            if (!isPlaying)
            {
                noise.Play();
                noise2.Play();
                isPlaying = true;
            }
            else
            {
                if (!noise2.isPlaying)
                {
                    goingToPlay = false;
                    isPlaying = false;
                    stateMachine.door1Lock = false; // Unlock the door after sound finishes
                }
            }
        }
    }
}
