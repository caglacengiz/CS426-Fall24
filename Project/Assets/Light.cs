using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public StateMachine stateMachine;
    public GameObject lightToBum;

    public int state;

    public bool flicker = true;

    public AudioSource bum;

    private float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        bum.Play();
        bum.Stop();
        
    }

    public float randomNumberGenerator(){
        return Random.Range(0.0f, 1.5f);
    }
    public void bumSound(){
        if(flicker){
            bum.Play();
        }
        turnOffLight();
    }
void turnOffLight(){
       lightToBum.SetActive(false);
   }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.state == state && flicker)
        {

            timer+=Time.deltaTime;
            if(timer>randomNumberGenerator()){
                toggleLight();
                timer=0;
            }
            
        }
        
    }
    void toggleLight(){
        lightToBum.SetActive(!lightToBum.activeSelf);
    }
}
