using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Joystick movementJoystick;
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
    public AudioClip jumpSound;
    public AudioClip resetPositionSound;
    private AudioSource audioSource;
    private Rigidbody playerRb;
    private GameObject playerCamera;
    private GameObject startPoint;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        startPoint = GameObject.Find("Start_Point");

        playerRb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("Camera");
    }

    void Update()
    {
        HandleJump();
    
        if (transform.position.y < -6)
        {
            ResetPosition();
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
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
    void HandleMovement()
    {
        float forwardForce = movementJoystick.Vertical * speed;
        float sideForce = movementJoystick.Horizontal * speed;

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
    void HandleJump()
    {
        // Проверяем касания
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Получаем первое касание

            // Проверяем, происходит ли касание на UI-элементе
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return; // Игнорируем касание, если оно происходит на UI
            }

            // Проверяем, попадает ли касание в область джойстика
            if (IsTouchOverJoystick(touch.position))
            {
                return; // Игнорируем касание, если оно попадает в область джойстика
            }

            // Обрабатываем касание для прыжка
            if (touch.phase == TouchPhase.Began && isOnGround)
            {
                Jump();
            }
        }
    }
    
    public void Jump()
    {
        if (isOnGround)
        {
            isOnGround = false;
            audioSource.PlayOneShot(jumpSound);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsTouchOverJoystick(Vector2 touchPosition)
    {
        // Преобразуем позицию касания в мировые координаты
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = touchPosition;

        // Проверяем, попадает ли касание в область джойстика
        GraphicRaycaster raycaster = movementJoystick.GetComponent<GraphicRaycaster>();
        if (raycaster != null)
        {
            System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
            raycaster.Raycast(pointer, results);

            foreach (var result in results)
            {
                if (result.gameObject == movementJoystick.gameObject)
                {
                    return true; // Касание попадает в область джойстика
                }
            }
        }

        return false; // Касание не попадает в область джойстика
    }
    public void ResetPosition()
    {
        audioSource.PlayOneShot(resetPositionSound);
        transform.position = startPoint.transform.position;
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        playerRb.linearVelocity *= 0;
        jumpForce = 15.0f;
    }
}
