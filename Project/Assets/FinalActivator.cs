using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalActivator : MonoBehaviour
{
    public ActivateFinal activateFinal;
    public StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")&&stateMachine.state==5) // If player enters trigger
        {
            activateFinal.isActivated=true;
            Debug.Log("Final Activated");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
