using UnityEngine;

public class ScreenLocation : MonoBehaviour
{
    
    [Header("Offset Screen")]
    [SerializeField, Range(0.01f, 1)] float offsetY = 0.2f;
    [SerializeField, Range(0.01f, 1)] float offsetX = 0.2f;

    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        MoveInScreenLocation();
    }

    void MoveInScreenLocation()
    {
        var newPosition = transform.position;

        var point = mainCamera.WorldToViewportPoint(transform.position); //Записываем положение объекта к границам камеры, X и Y это будут как раз верхние и нижние границы камеры

        if (point.y < 0f - offsetY)
        {
            newPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(point.x, 1, point.z)).y;
            transform.position = newPosition;
        }
        else if (point.y > 1 + offsetY)
        {
            newPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(point.x, 0, point.z)).y;
            transform.position = newPosition;
        }
        else if (point.x > 1f + offsetX)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0, point.y, point.z)).x;
            transform.position = newPosition;
        }
        if (point.x < 0f - offsetX)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1, point.y, point.z)).x;
            transform.position = newPosition;
        }
    }
}
