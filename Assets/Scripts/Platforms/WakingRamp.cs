using UnityEngine;

public class WakingRamp : MonoBehaviour
{
    private float speed = 25f;
    private float downSpeed = 35;
    private Rigidbody rampRb;
    private AudioSource audioSource;
    public AudioClip sound;
    public bool isOnTrigger = false;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rampRb = GameObject.Find("Waking_Ramp").GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        isOnTrigger = true;
        audioSource.PlayOneShot(sound);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        isOnTrigger = false;
        }
    }
    

    void FixedUpdate()
    {
        if (rampRb.transform.position.y > -2.0f && !isOnTrigger)
        {
            rampRb.AddForce(Vector3.down * downSpeed, ForceMode.Acceleration);
        }
    
        if (rampRb.transform.position.y < 2.0f && isOnTrigger)
        {
            rampRb.AddForce(Vector3.up * speed, ForceMode.Acceleration);
        }
    }
}
