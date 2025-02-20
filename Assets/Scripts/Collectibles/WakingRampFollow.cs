using UnityEngine;

public class WakingRampFollow : MonoBehaviour
{
    public GameObject platform;
    void Update()
    {
        Vector3 offset = new Vector3(-3.53f, 3.1f, 2.799999f);
        transform.position = platform.transform.position + offset;
    }
}
