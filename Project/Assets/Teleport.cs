using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportDestination;  // Destination trigger's transform
    private bool isReadyToTeleport = true; // Prevent immediate retriggering
    public static Transform lastTeleportedTrigger; // Track the last trigger

    public StateMachine stateMachine;

    public GameObject sandalye1;
    public GameObject masa;
    public GameObject kitap;
    public GameObject şişe1;
    public GameObject şişe2;
    public GameObject sandalye2;
    public GameObject yatak;
    public GameObject yatakIc;

    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;

    public GameObject lightToClose;
    public GameObject lightToClose2;
    public GameObject lightToClose3;

    public GameObject besik;

    public PlayNoise playNoiseBaby;
    public PlayNoise playNoiseWhisper;

    public AudioSource crackingSound;

    public UnityEngine.Light lt;
    public UnityEngine.Light lt2;
    public UnityEngine.Light lt3;
    public UnityEngine.Light lt4;
    private Color oldColor;

    public PacifierSpawner pacifierSpawner;
    

void Start()
    {
        oldColor=lt.color;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player") && isReadyToTeleport && stateMachine.readTheNote && !playNoiseBaby.isPlaying && !playNoiseWhisper.isPlaying ) // If player enters trigger
        {

            UpdateState();
            

            if (lastTeleportedTrigger != this.transform) // Avoid bouncing back immediately
            {
                Vector3 contactPoint = collision.ClosestPoint(transform.position); // Get exact contact point
                Vector3 offset = CalculateOffset(contactPoint);
                StartCoroutine(TeleportPlayer(collision.gameObject, offset));
            }
        }
    }
    void UpdateState(){
        //do something
        //stateMachine.door1Lock=true;

        if(stateMachine.state==0){
            stateMachine.state=1;
            note2.SetActive(true);
            masa.SetActive(false);
            note1.SetActive(false);
            kitap.SetActive(false);
            şişe1.SetActive(false);
            şişe2.SetActive(false);
            lightToClose.SetActive(false);
            lightToClose2.SetActive(false);
            lightToClose3.SetActive(false);
        }
        else if(stateMachine.state==1){
            stateMachine.state=2;
            note2.SetActive(false);
            note3.SetActive(true);
            sandalye2.SetActive(false);
        }
        else if (stateMachine.state==2){
            stateMachine.state=3;
            note3.SetActive(false);
            note4.SetActive(true);
            sandalye1.SetActive(false);
        }
        else if (stateMachine.state==3){
            stateMachine.state=4;
            note4.SetActive(false);
            note5.SetActive(true);
            yatak.SetActive(false);
            besik.SetActive(true);
            lt.color=Color.red;
            lt2.color=Color.red;
            lt3.color=Color.red;
            lt4.color=Color.red;
            Debug.Log(lt.color);
        }else if (stateMachine.state==4){
            stateMachine.state=5;
            //chnage the color of the light to FFD69E
            lt.color=oldColor;
            lt2.color=oldColor;
            lt3.color=oldColor;
            lt4.color=oldColor;
            Debug.Log(lt.color);
            besik.SetActive(false);
            crackingSound.Stop();
            stateMachine.door1Lock=true;
        }
        

        stateMachine.readTheNote=false;
    }
    Vector3 CalculateOffset(Vector3 contactPoint)
    {
        // Calculate the relative position (X and Z only)
        float offsetX = contactPoint.x - transform.position.x;
        float offsetZ = contactPoint.z - transform.position.z;

        return new Vector3(offsetX, 0, offsetZ); // Ignore Y offset
    }

    IEnumerator TeleportPlayer(GameObject player, Vector3 offset)
    {
        isReadyToTeleport = false;

        CharacterController controller = player.GetComponent<CharacterController>();
        PlayerController playerController = player.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.SetTeleporting(true); // Stop movement temporarily
        }

        if (controller != null)
        {
            controller.enabled = false; // Temporarily disable to avoid glitches
        }

        if (teleportDestination != null)
        {
            // Apply the X and Z offsets and fix Y to 2.64
            Vector3 targetPosition = teleportDestination.position + offset;
            targetPosition.y = 2.64f; // Fixed Y position

            // Set player position
            player.transform.position = targetPosition;

            lastTeleportedTrigger = teleportDestination;
        }

        yield return new WaitForSeconds(0.1f); // Small cooldown

        if (controller != null)
        {
            controller.enabled = true; // Re-enable controller
        }

        if (playerController != null)
        {
            playerController.SetTeleporting(false); // Resume movement
        }

        isReadyToTeleport = true;
    }
}
