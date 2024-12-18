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
    public GameObject not;
    public GameObject kitap;
    public GameObject şişe1;
    public GameObject şişe2;
    public GameObject sandalye2;
    public GameObject yatak;
    public GameObject yatakIc;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player") && isReadyToTeleport)
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
        Debug.Log(stateMachine.state);
        if(stateMachine.state==0){
            stateMachine.state=1;
            masa.SetActive(false);
            not.SetActive(false);
            kitap.SetActive(false);
            şişe1.SetActive(false);
            şişe2.SetActive(false);
            
        }
        else if(stateMachine.state==1){
            
        }
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
