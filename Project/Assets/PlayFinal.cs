using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayFinal : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource scream;
    bool didPlay = false;
    void Start()
    {
        
        StartCoroutine(FinalSequence());

        
    }
    IEnumerator FinalSequence(){
        yield return new WaitForSeconds(1);
        scream.Play();
        didPlay = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(!scream.isPlaying&&didPlay){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
        }
    }
}
