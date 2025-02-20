using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float rotationSpeed = 200.0f;
    public GameObject platform;
    public GameObject colorEffect;
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (platform != null)
        {
            Vector3 offset = new Vector3(0, 1.5f, 0);
            transform.position = platform.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(colorEffect, transform.position, Quaternion.identity);
        }
    }
}
