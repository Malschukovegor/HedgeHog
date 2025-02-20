using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 15;
    public AudioClip collisionSound;
    private AudioSource audioSource;
    private Rigidbody enemyRb;
    private GameObject player;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Hedgehog_2");        
    }

    void Update()
    {
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Untagged") 
        || collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
