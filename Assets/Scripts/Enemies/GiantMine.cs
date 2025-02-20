using UnityEngine;
using UnityEngine.UIElements;

public class GiantMine : MonoBehaviour
{
    public float speed = 15;
    public bool outOfBounds = false;
    private Rigidbody enemyRb;
    private GameObject player;
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Hedgehog");        
    }
    void Update()
    {
        if (transform.position.z >= 5.5f && transform.position.z <= -19)
        {
            outOfBounds = true;
        }
        else 
        {
            outOfBounds = false;
        }

        if (transform.position.x >= 19 && transform.position.x <= 6)
        {
            outOfBounds = true;
        }
        else
        {
            outOfBounds = false;
        }

        if (outOfBounds)
        {
            speed = 0.0f;
        }
        else
        {
            speed = 15.0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed, ForceMode.Acceleration);
    }
}
