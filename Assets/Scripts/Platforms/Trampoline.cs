using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float speed = 80.0f;
    public float downSpeed = 100.0f;
    private Rigidbody trampolineRb;
    private AudioSource audioSource;
    public AudioClip trampolineSound;
    public bool isOnTrigger = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        trampolineRb = GameObject.Find("Trampoline").GetComponent<Rigidbody>();  
    }
    void FixedUpdate()
    {
        if (isOnTrigger && trampolineRb.transform.position.y < 1.5)
        {
            trampolineRb.AddForce(Vector3.up * speed, ForceMode.Acceleration);
        }
        else if (!isOnTrigger && trampolineRb.transform.position.y > 1)
        {
           trampolineRb.AddForce(Vector3.down * downSpeed, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(trampolineSound);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = false;
        }
    }
}
