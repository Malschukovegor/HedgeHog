using Unity.VisualScripting;
using UnityEngine;

public class PushinGlider : MonoBehaviour
{
    private float speed = 100.0f;
    private Rigidbody gliderRb;
    private GameObject pushinGlider;
    private AudioSource audioSource;
    public AudioClip pushinGliderSound;
    public bool isOnTrigger = false;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gliderRb = GameObject.Find("Pushin_Glider").GetComponent<Rigidbody>();
        pushinGlider = GameObject.Find("Pushin_Glider");
    }

    void FixedUpdate()
    {
       if(pushinGlider.transform.position.x > 4.5f && isOnTrigger)
       {
            gliderRb.AddForce(Vector3.left * speed, ForceMode.Acceleration);
       }  
       else if(pushinGlider.transform.position.x < 14 && !isOnTrigger) 
       {
            gliderRb.AddForce(Vector3.right * speed, ForceMode.Acceleration);
       } 
    }
    

    void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(pushinGliderSound);
        isOnTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        isOnTrigger = false;
    }
}
