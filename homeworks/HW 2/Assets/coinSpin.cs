using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpin : MonoBehaviour
{
    public GameObject coin;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;
    public GameObject coin9;
    public GameObject coin10;
    public GameObject coin11;
    public GameObject coin12;
    public GameObject coin13;
    public GameObject coin14;
    public GameObject coin15;
    public GameObject[] coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = new GameObject[15];
        coins[0] = coin;
        coins[1] = coin2;
        coins[2] = coin3;
        coins[3] = coin4;
        coins[4] = coin5;
        coins[5] = coin6;
        coins[6] = coin7;
        coins[7] = coin8;
        coins[8] = coin9;
        coins[9] = coin10;
        coins[10] = coin11;
        coins[11] = coin12;
        coins[12] = coin13;
        coins[13] = coin14;
        coins[14] = coin15;


        StartCoroutine(spinCoin());

    }

    IEnumerator spinCoin()
    {
        while(true)
        {


            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] != null){
                    coins[i].transform.Rotate(0, 0, 1);
                }
                
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
