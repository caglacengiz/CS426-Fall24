using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BriefScript : MonoBehaviour
{
    public AudioSource doorSound;
    public int wait;
    private bool isActive=true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorSound.isPlaying&&isActive){
            isActive=false;
            //next scene
            Debug.Log("Next Scene");
            StartCoroutine(waitAndGoToNextScene());
            
        }
        
    }
    IEnumerator waitAndGoToNextScene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator playSound(){
        yield return new WaitForSeconds(wait);
        doorSound.Play();
    }
}
