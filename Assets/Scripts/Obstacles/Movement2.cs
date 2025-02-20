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
        obstacleRb.AddTorque(rotationSpeed * Time.deltaTime * Vector3.right, ForceMode.Acceleration);
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
            obstacleRb.AddForce(movementSpeed * Time.fixedDeltaTime * Vector3.up, ForceMode.Acceleration);
        }
        else
        {
            obstacleRb.AddForce(movementSpeed * Time.fixedDeltaTime * Vector3.down, ForceMode.Acceleration);
        }
    }
}
