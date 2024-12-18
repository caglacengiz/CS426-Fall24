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
    // Start is called before the first frame update
    public StateMachine stateMachine;
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
        if (Input.GetKeyDown(KeyCode.R)&& Action) // If R is pressed
        {
            NoteUI.SetActive(true);
            playerController.LockMovement();
            PaperSound.Play();
        }else if (Input.GetKeyDown(KeyCode.Escape) && Action)
        {
            stateMachine.door1Lock = false;
            NoteUI.SetActive(false);
            playerController.UnlockMovement();
            PaperSound.Play();
        }
    }
}
