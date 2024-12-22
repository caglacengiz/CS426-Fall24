using UnityEngine;

public class PacifierPhysics : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        Vector3 randomForce = new Vector3(
            Random.Range(-5f, 5f), 
            Random.Range(5f, 10f), 
            Random.Range(-5f, 5f)  
        );

        rb.AddForce(randomForce, ForceMode.Impulse);

        
        Vector3 randomTorque = new Vector3(
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f)
        );

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
