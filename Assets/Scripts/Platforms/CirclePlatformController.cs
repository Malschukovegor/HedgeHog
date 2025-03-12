using UnityEngine;

public class CirclePlatformController : MonoBehaviour
{
    public bool topBorderTouched = false;
    public float topBorder = 7.0f;
    public float bottomBorder = 3.99f;
    private float rotationSpeed = 10.0f;
    private float verticalSpeed = 70.0f;
    private Rigidbody platformRb;

    void Awake()
    {
        platformRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y >= topBorder)
        {
            topBorderTouched = true;
        }
        else if (transform.position.y < bottomBorder)
        {
            topBorderTouched = false;
        }

        platformRb.AddTorque(rotationSpeed * Time.deltaTime * Vector3.up, ForceMode.Acceleration);
    }

    void FixedUpdate()
    {
        if (!topBorderTouched)
        {
            platformRb.AddForce(Time.fixedDeltaTime * verticalSpeed * Vector3.up, ForceMode.Acceleration);
        }
        else
        {
            platformRb.AddForce(Time.fixedDeltaTime * verticalSpeed * Vector3.down, ForceMode.Acceleration);
        }
    }
}
