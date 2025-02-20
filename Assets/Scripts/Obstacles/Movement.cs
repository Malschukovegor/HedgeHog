using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody obstacleRb;
    public float rotationSpeed = 250.0f;

    void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        obstacleRb.AddTorque(Vector3.right * rotationSpeed * Time.deltaTime, ForceMode.Acceleration);
    }
}
