using UnityEngine;
using UnityEngine.EventSystems;

public class CameraSwipeController : MonoBehaviour
{
    private Transform target; // Объект, вокруг которого вращается камера
    public float distance = 1.5f; // Дистанция от камеры до объекта
    public float sensitivity = 0.3f; // Чувствительность свайпов
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Vector2 touchStartPos; // Начальная позиция касания
    private bool isSwiping = false; // Флаг для отслеживания свайпа
    public Joystick movementJoystick; // Ссылка на джойстик для движения
    public bool camButtonTouched = false;

    // Границы зоны для свайпов (в процентах от ширины экрана)
    public float swipeZoneWidthPercentage = 50f; // Правые 50% экрана

    void Awake()
    {
        target = GameObject.Find("Hedgehog_2").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        HandleTouchInput();
        HandleCameraRotation();
    }

    void HandleTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Игнорируем касание, если оно происходит на UI
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                continue;
            }

            // Игнорируем касания в области джойстика
            if (IsTouchOverJoystick(touch.position))
            {
                continue;
            }

            // Проверяем, находится ли касание в зоне свайпов
            if (!IsTouchInSwipeZone(touch.position))
            {
                continue;
            }

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 delta = touch.position - touchStartPos;
                        rotationX -= delta.y * sensitivity;
                        rotationY += delta.x * sensitivity;
                        touchStartPos = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }

    void HandleCameraRotation()
    {
        rotationX = Mathf.Clamp(rotationX, -90f, 50f);
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = rotation;

        if (target != null)
        {
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
            transform.position = position;
        }
    }

    bool IsTouchOverJoystick(Vector2 touchPosition)
    {
        if (movementJoystick != null)
        {
            RectTransform joystickRect = movementJoystick.GetComponent<RectTransform>();
            Vector2 localTouchPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                joystickRect,
                touchPosition,
                null,
                out localTouchPosition))
            {
                return joystickRect.rect.Contains(localTouchPosition);
            }
        }
        return false;
    }

    bool IsTouchInSwipeZone(Vector2 touchPosition)
    {
        // Вычисляем ширину зоны свайпов
        float swipeZoneWidth = Screen.width * (swipeZoneWidthPercentage / 100f);

        // Проверяем, находится ли касание правее границы зоны свайпов
        return touchPosition.x > (Screen.width - swipeZoneWidth);
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

