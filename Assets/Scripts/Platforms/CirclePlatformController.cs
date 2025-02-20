using UnityEngine;

public class CirclePlatformController : MonoBehaviour
{
    public bool topBorderTouched = false;
    public float topBorder = 7.0f;
    public float bottomBorder = 3.99f;
    public float rotationSpeed = 0.5f;
    private float verticalSpeed = 1.5f;
    private Rigidbody circlePlatformRb;
    void Awake()
    {
        circlePlatformRb = GetComponent<Rigidbody>();
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

        if (!topBorderTouched)
        {
            transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
        }

        
    }
    void FixedUpdate()
    {
        circlePlatformRb.AddTorque(Vector3.up * rotationSpeed, ForceMode.Acceleration);
    }
}
