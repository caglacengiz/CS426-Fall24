using System.Collections;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;          // UI instruction to press E
    public GameObject AnimeObject;          // Door GameObject with Animator
    public AudioSource DoorOpenSound;       // Audio Source for the door opening sound
    public bool Action = false;             // Whether the player is in range
    private bool isDoorOpen = false;        // To prevent repeated presses
    public AudioSource DoorCloseSound;       // Audio Source for the door closing sound
    public StateMachine stateMachine;

    public string doorName;

    void Start()
    {
        Instruction.SetActive(false);       // Hide instruction at the start
    }

    void OnTriggerEnter(Collider collision)
    {
    bool doorLock=false;
    if(doorName=="Door1"){
        doorLock=stateMachine.door1Lock;
    }
    else if(doorName=="Door2"){
        doorLock=stateMachine.door2Lock;
    }
    
    if(!doorLock){
        if (collision.transform.CompareTag("Player")) // If player enters trigger
        {
            if(isDoorOpen==false){
            Instruction.SetActive(true);   // Show UI instruction
            Action = true;                 // Allow interaction
            }
        }
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action && !isDoorOpen) // If E is pressed
        {
            StartCoroutine(OpenAndCloseDoor()); // Start door open/close sequence
        }
    }

    IEnumerator OpenAndCloseDoor()
    {
        isDoorOpen = true; // Prevent spamming E

        // Play open animation and sound
        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
        DoorOpenSound.Play();

        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Play close animation
        AnimeObject.GetComponent<Animator>().Play("DoorClose");
        yield return new WaitForSeconds(0.7f);
        DoorCloseSound.Play();

        // Wait briefly to ensure the animation finishes
        yield return new WaitForSeconds(1);

        isDoorOpen = false; // Allow interaction again
    }
}
