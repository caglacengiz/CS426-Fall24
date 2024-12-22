using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivateFinal : MonoBehaviour
{
    public PlayerController playerController;
    public bool isActivated = false;
    public PacifierSpawner pacifierSpawner;
    public AudioSource heartBeat;
    public AudioSource laugh;
    public UnityEngine.Light lt;
    public UnityEngine.Light lt2;
    // Start is called before the first frame update
    void Start()
    {
        heartBeat.Stop();
        laugh.Stop();
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")&&isActivated) // If player enters trigger
        {
            Debug.Log("Stop Movement");
            playerController.LockMovementWithoutCursor();
            StartCoroutine(FinalSequence());
            
        }
    }
    IEnumerator FinalSequence(){
        yield return new WaitForSeconds(3);
        
        heartBeat.Play();
        laugh.Play();
        yield return new WaitForSeconds(5);
        lt.color = Color.red;
        lt2.enabled = false;
        pacifierSpawner.SpawnAllPacifiers();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
