using UnityEngine;

public class CameraJoystickController : MonoBehaviour
{
    private Transform target; // Объект, вокруг которого вращается камера
    public float distance = 1.5f; // Дистанция от камеры до объекта
    public float sensitivity = 50.0f; // Чувствительность джойстика
    public Joystick cameraJoystick; // Ссылка на виртуальный джойстик
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private bool camButtonTouched = false;

    void Awake()
    {
        target = GameObject.Find("Hedgehog_2").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (cameraJoystick != null)
        {
            // Получаем ввод от джойстика
            float horizontal = cameraJoystick.Horizontal * sensitivity * Time.deltaTime;
            float vertical = cameraJoystick.Vertical * sensitivity * Time.deltaTime;

            // Вращение камеры
            rotationX -= vertical;
            rotationX = Mathf.Clamp(rotationX, -90f, 50f); // Ограничение угла по вертикали
            rotationY += horizontal;

            // Применяем вращение к камере
            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation = rotation;

            // Позиционируем камеру относительно цели
            if (target != null)
            {
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;
                transform.position = position;
            }
        }
    }

    public void CameraToggle()
    {
        if (!camButtonTouched)
        {
            distance = -5.2f;
            camButtonTouched = true;
        }
        else
        {
            distance = 1.5f;
            camButtonTouched = false;
        }
    }
}