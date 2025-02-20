using UnityEngine;

public class Movement3 : MonoBehaviour
{
    public float rotationSpeed = 1.4f;
    private Rigidbody obstacleRb;
    void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        obstacleRb.AddTorque(Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.Acceleration);
    }
}
