using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    private float upSpeed = 10.0f;
    private float downSpeed = 2.0f;
    private AudioSource audioSource;
    public AudioClip doorSound;
    public bool isOnTrigger = false;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        isOnTrigger = true;
        audioSource.PlayOneShot(doorSound);
    }
    
    void OnTriggerExit(Collider other)
    {
        isOnTrigger = false;
    }

    void Update()
    {
        if (door.transform.position.y > 2 && !isOnTrigger)
        {
            door.transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        }
        else if (door.transform.position.y < 5 && isOnTrigger)
        {
            door.transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
        }
    }
}   
