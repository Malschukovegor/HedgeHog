using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject player;
    public AudioClip jumpSound;
    public AudioClip resetPositionSound;
    void Awake()
    {
        player = GameObject.Find("Hedgehog_2");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpSound);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.PlayOneShot(resetPositionSound);
        }
    }
}
