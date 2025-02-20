using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private Rigidbody obstacleRb;
    public float rotationSpeed = 1.5f;
    public float movementSpeed = 4;
    public bool topBorderTouched = false;

    void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        obstacleRb.AddTorque(Vector3.right * rotationSpeed, ForceMode.Acceleration);
    }

    void FixedUpdate()
    {
        if (transform.position.y >= 10)
        {
            topBorderTouched = true;
        }
        else if (transform.position.y <= 3.0f)
        {
            topBorderTouched = false;
        }

        if (!topBorderTouched)
        {
            obstacleRb.AddForce(Vector3.up * movementSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else
        {
            obstacleRb.AddForce(Vector3.down * movementSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
}
