using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowChair : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public StateMachine stateMachine;
    public bool isThrown = false;
    public AudioSource sandalye;
    public AudioSource sandalyeDrop;
    void Start()

    {
        sandalye.Stop();
        sandalyeDrop.Stop();
    }
    //check collision
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player")&&stateMachine.state==1 && !isThrown) // If player enters trigger
        {
            isThrown = true;
            StartCoroutine(WaitAndThrow());
        }
    }
    IEnumerator WaitAndThrow()
    {   
        yield return new WaitForSeconds(3);
        //add a force to the pacifie
        sandalye.Play();
            Vector3 randomForce = new Vector3(
                1f,
                0,
                -5f
            );
            rb.AddForce(randomForce * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        sandalyeDrop.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
