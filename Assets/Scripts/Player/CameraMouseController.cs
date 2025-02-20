using UnityEngine;

public class CameraMouseController : MonoBehaviour
{
    private Transform target; // Объект, вокруг которого вращается камера
    public float distance = 1.5f; // Дистанция от камеры до объекта
    public float sensitivity = 100.0f; // Чувствительность мыши
    public bool vButtonTouched = false;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    void Awake()
    {
        target = GameObject.Find("Hedgehog_2").GetComponent<Transform>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Блокировка курсора в центре экрана
        Cursor.visible = false; // Скрытие курсора
    }

    void LateUpdate()
    {
        // Получаем ввод от мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Вращение камеры
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 50f); // Ограничение угла по вертикали

        rotationY += mouseX;

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

        if (Input.GetKeyDown(KeyCode.V) && !vButtonTouched)
        {
            distance = -5.2f;
            vButtonTouched = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) && vButtonTouched)
        {
            distance = 1.5f;
            vButtonTouched = false;
        }
    }
}
