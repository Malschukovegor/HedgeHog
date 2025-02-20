using UnityEngine;

public class PlatformFlyFwd : MonoBehaviour
{
    public float speed = 3f;
    public float backBorder = 11.3f;
    public float frontBorder = 16.8f;
    public bool backBorderTouched = false;
    private Rigidbody platformRb;
    
    void Awake()
    {
        platformRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.z <= backBorder)
        {
            backBorderTouched = true;
        }
        else if (transform.position.z >= frontBorder)
        {
            backBorderTouched = false;
        }
        
        if (!backBorderTouched)
        {
            platformRb.AddForce(Vector3.back * speed, ForceMode.Acceleration);
        }
        else
        {
            platformRb.AddForce(Vector3.forward * speed, ForceMode.Acceleration);
        }
    }
}
