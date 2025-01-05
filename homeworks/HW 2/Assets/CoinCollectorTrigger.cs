using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public CoinCounter coinCounter;
    public GameObject coin;


    void Start()
    {

        
    }

    //on collision with the player, increment the coin count and destroy the coin. Use collision not collider
    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinCounter.incrementCoinCount();
            Destroy(coin);
        }
    }*/

    //use collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinCounter.IncrementCoinCount();
            Destroy(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
