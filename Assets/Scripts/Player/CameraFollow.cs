using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 85.0f;
    public bool buttonTouched = false;
    private GameObject mainCamera;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;

        RotationControl();
        ZoomingControl();
    }

    private void RotationControl()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }

    private void ZoomingControl()
    {
        if (Input.GetKeyDown(KeyCode.V) && !buttonTouched)
        {
            Vector3 forwardOffset = transform.forward;
            Vector3 downOffset = transform.up;
            Vector3 offset = (forwardOffset*5f) - (downOffset*12);
            mainCamera.transform.position += offset;

            buttonTouched = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) && buttonTouched)
        {
            Vector3 forwardOffset = transform.forward;
            Vector3 downOffset = transform.up;
            Vector3 offset = (forwardOffset*5f) - (downOffset*12);
            mainCamera.transform.position -= offset;

            buttonTouched = false;
        }
    }
}
