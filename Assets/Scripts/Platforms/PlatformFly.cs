using UnityEngine;

public class PlatformFly : MonoBehaviour
{
    public float flightSpeed = 3;
    public bool rightBorderTouched = false;
    public float rightBorder = -16.0f;
    public float leftBorder = -19.0f;
    private Rigidbody platformRb;

    void Awake()
    {
        platformRb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (transform.position.x >= rightBorder)
        {
            rightBorderTouched = true;
        }
        else if (transform.position.x <= leftBorder)
        {
            rightBorderTouched = false;
        }

        if (!rightBorderTouched)
        {
            platformRb.AddForce(Vector3.right * flightSpeed, ForceMode.Acceleration);
        }
        else
        {
            platformRb.AddForce(Vector3.left * flightSpeed, ForceMode.Acceleration);
        }
    }
}
