using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelRunner : MonoBehaviour
{
    public float barrelRollSpeed = 1;
    public float barrelMoveSpeed = 0.1f;
    public GameObject barrel;
    public GameObject barrelCollider;
    public Vector3 target;
    public Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        //teleport the barrel to the start position
        start = barrel.transform.position;
        target = barrelCollider.transform.position;
        StartCoroutine(barrelRoll());
        StartCoroutine(barrelyMove());
        
    }


  

    IEnumerator barrelRoll()
    {
        while(true)
        {
            barrel.transform.Rotate(0, -barrelRollSpeed,0 );
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator barrelyMove()
    {
        while(true)
        {
            if(barrel.transform.position.z <= target.z)
            {
                barrel.transform.position = start;
            }

            barrel.transform.position = barrel.transform.position + new Vector3(0, 0, -barrelMoveSpeed);
            
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player lost! Barrel hit.");
        SceneManager.LoadScene("LoseScene"); // Direkt kaybetme sahnesine geç
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
