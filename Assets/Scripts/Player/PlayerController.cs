using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 18;
    public float maxSpeed = 13f;
    public float jumpForce = 15;
    public bool isOnGround = false;
    public bool hasPowerup = false;
    public GameObject powerup;
    public float powerupPositionX = -21.0f;
    public float powerupPositionY = 6.3f;
    public float powerupPositionZ = -0.2f;
    public AudioClip coinSound;
    public AudioClip powerupTake;
    public AudioClip powerupDismiss;
    public AudioClip destroyEnemies;
    public AudioClip hitSurface;
    private AudioSource audioSource;
    private Rigidbody playerRb;
    private GameObject playerCamera;
    private Vector3 startPosition = new Vector3(-21.0f, 20.0f, -23.0f);
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("Camera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);            
        }

        if (transform.position.y < -6 || Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition;
            transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
            playerRb.linearVelocity *= 0;
            jumpForce = 15.0f;
        }
    }

    void FixedUpdate()
    {
        float forwardForce = Input.GetAxis("Vertical") * speed;
        float sideForce = Input.GetAxis("Horizontal") * speed;

        if (isOnGround)
        {
            playerRb.AddForce(playerCamera.transform.forward * forwardForce, ForceMode.Acceleration);
            playerRb.AddForce(playerCamera.transform.right * sideForce, ForceMode.Acceleration);
        }

        if (playerRb.linearVelocity.magnitude > maxSpeed)
        {
            playerRb.linearVelocity = playerRb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                audioSource.PlayOneShot(hitSurface);
                isOnGround = true;
            }
            else if (collision.gameObject.CompareTag("Untagged"))
            {
                audioSource.PlayOneShot(hitSurface);
            }
        }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            
            audioSource.PlayOneShot(powerupTake);
            hasPowerup = true;
            Destroy(other.gameObject);
            jumpForce = 25;
            maxSpeed = 16;
            Vector3 offset = new Vector3(0, 0.7f, 0);
            transform.position += offset;
            transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            StartCoroutine(PowerupCountDownRoutine());
        }

        if (other.CompareTag("Powerup_Red"))
        {
            audioSource.PlayOneShot(powerupTake);
            hasPowerup = true;
            Destroy(other.gameObject);
            jumpForce = 25;
            maxSpeed = 16;
            Vector3 offset = new Vector3(0, 0.7f, 0);
            transform.position += offset;
            transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }

        if (other.CompareTag("Powerup_Yellow") && hasPowerup)
        {
            audioSource.PlayOneShot(powerupDismiss);
            hasPowerup = false;
            Destroy(other.gameObject);
            jumpForce = 15;
            maxSpeed = 13;
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }

        if (other.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound);
        }

        if (other.CompareTag("Enemy_Destroyer"))
        {
            audioSource.PlayOneShot(destroyEnemies);
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(10);
        audioSource.PlayOneShot(powerupDismiss);
        hasPowerup = false;
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        jumpForce = 15;
        maxSpeed = 13;
        Vector3 powerupPosition = new Vector3(powerupPositionX, powerupPositionY, powerupPositionZ);
        Instantiate(powerup, powerupPosition, powerup.transform.rotation);
    }
}
