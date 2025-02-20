using UnityEngine;

public class SceneRotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 3);
    }
}
