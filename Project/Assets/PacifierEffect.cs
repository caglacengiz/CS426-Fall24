using UnityEngine;

public class PacifierEffect : MonoBehaviour
{
    private Rigidbody rb;
    private bool isLanded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isLanded && collision.gameObject.CompareTag("Floor")) 
        {
            StartCoroutine(ShakeAndStop());
        }
    }

    System.Collections.IEnumerator ShakeAndStop()
    {
        isLanded = true;

        
        float shakeDuration = 2.0f;
        while (shakeDuration > 0)
        {
            transform.position += Random.insideUnitSphere * 0.05f;
            shakeDuration -= Time.deltaTime;
            yield return null;
        }

        
        rb.isKinematic = true;
    }
}
