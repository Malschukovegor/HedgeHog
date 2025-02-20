using UnityEngine;

public class Moving : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float movingSpeed = 10.0f;
    public float topBorder = 5.7f;
    public float bottomBorder = 2.9f;
    public bool topBorderTouched = false;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        if (transform.position.y >= topBorder)
        {
            topBorderTouched = true;
        }
        else if (transform.position.y <= bottomBorder)
        {
            topBorderTouched = false;
        }

        if (!topBorderTouched)
        {
            transform.Translate(movingSpeed * Time.deltaTime * Vector3.up);
        }
        else
        {
            transform.Translate(movingSpeed * Time.deltaTime * Vector3.down);
        }
    }
}
