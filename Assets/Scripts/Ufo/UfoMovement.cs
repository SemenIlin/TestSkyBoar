using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    [SerializeField] float timeOfMovement;

    UfoSpawner ufoSpawner;
    Camera mainCamera;

    float speedMovement;
    void Start()
    {
        mainCamera = Camera.main;
        ufoSpawner = transform.parent.GetComponent<UfoSpawner>();
        if (timeOfMovement > 0) 
        {
            speedMovement = Screen.WidthScreen / timeOfMovement;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(ufoSpawner.MovementDirection * Time.fixedDeltaTime * speedMovement);
        DestroyUfo();
    }

    void DestroyUfo()
    {
        var newPosition = transform.position;

        var point = mainCamera.WorldToViewportPoint(transform.position);                
        if (point.x > 1f)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0, point.y, point.z)).x;
            Destroy(gameObject);
        }
        if (point.x < 0f)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1, point.y, point.z)).x;
            Destroy(gameObject);
        }
    }
}
