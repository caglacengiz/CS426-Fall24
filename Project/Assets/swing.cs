using UnityEngine;

public class swing : MonoBehaviour
{
    // Use this for initialization
	public float speed = 10;
	public float RotAngleY = 10;
	    public float minAngle = -100; // Minimum rotation angle
    public float maxAngle = -80; // Maximum rotation angle

    void Update()
    {
        // Calculate the midpoint and amplitude of the swing range
        float midpoint = (minAngle + maxAngle) / 2;
        float amplitude = (maxAngle - minAngle) / 2;

        // Calculate the swing angle using Mathf.PingPong
        float rX = midpoint + Mathf.PingPong(Time.time * speed, 2 * amplitude) - amplitude;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(rX, 0, 0);
    }

    
}
