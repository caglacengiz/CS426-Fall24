using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyReadNote : MonoBehaviour
{   
    public GameObject Instruction;          // UI instruction to press E
    public PlayerController playerController;
    public AudioSource PaperSound;       // Audio Source for the door closing sound
    
    public bool Action = false;             // Whether the player is in range
    public GameObject NoteUI;

    public bool isOpened = false;
    // Start is called before the first frame update
    public StateMachine stateMachine;

    public Light lightToBum;

    public 
    void Start()
    {
        Instruction.SetActive(false);       // Hide instruction at the start
        NoteUI.SetActive(false);
        Action = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")) // If player enters trigger
        {
            Instruction.SetActive(true);   // Show UI instruction
            Action = true;                 // Allow interaction
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("Player")) // If player leaves trigger
        {
            Instruction.SetActive(false);  // Hide UI instruction
            Action = false;                // Block interaction
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&& Action && !isOpened) // If R is pressed
        {
            isOpened = true;
            NoteUI.SetActive(true);
            playerController.LockMovement();
            PaperSound.Play();
        }else if (Input.GetKeyDown(KeyCode.Q) && Action && isOpened) // If E is pressed
        {
            Debug.Log("Q Pressed");
            
            if(lightToBum!= null){
                Debug.Log(lightToBum.state);
                Debug.Log("Light to Bum");
                if(stateMachine.state == lightToBum.state){
                    lightToBum.bumSound();
                    lightToBum.flicker = false;
                
            }
            }
            
            isOpened = false;
            stateMachine.door1Lock = false;
            stateMachine.readTheNote = true;
            NoteUI.SetActive(false);
            playerController.UnlockMovement();
            if(lightToBum==null){
                PaperSound.Play();
            }
            
        }
    }
}
